
var table;

// popula listagem geral de usuários
function Popular() {

    table = $('#table').DataTable({
        destroy: true,
        loading: true,
        ajax: {
            //url: 'http://localhost:9617/usuario/resgatartodos',
            url: '/usuario/resgatartodos',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            dataSrc: '',
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        },
        columns: [
                    { title: 'ID', data: 'idusuario' },
                    { title: 'Login', data: 'login' },
                    { title: 'Nome', data: 'nome' },
                    { title: 'Email', data: 'email' },
                    { title: 'Nível', data: 'nivel' },
                    { title: 'Segmentação', data: 'segmentacao' },
                    { title: 'Situação', data: 'fativo' },
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    {
                        title: 'Editar', data: null, orderable: false,
                        render: function (data, type) {
                            return '<i class="material-icons tb-editbtn" title="Editar">edit</i>'
                        }
                    }
        ],
        scrollX: true,
        oLanguage: {
            oPaginate: {
                sNext: "Próxima",
                sPrevious: "Anterior"
            },
            sSearch: "Procurar:",
            sZeroRecords: "Nenhum registro encontrado",
            sInfoEmpty: "Nenhum registro encontrado",
            sEmptyTable: "Nenhum registro encontrado",
            sLengthMenu: "Mostrar _MENU_ registros por página",
            sInfoFiltered: " - Filtrado de _MAX_ registro(s)",
            sInfo: "Mostrando _END_ registro(s) dos _TOTAL_ encontrado(s)"
        }
    });
}

// popular lista de segmentações ativas (usado para inserir ou editar usuario)
function PopularSegmentacoes() {

    $.ajax({
        //url: 'http://localhost:9617/segmentacao/resgatarativas',
        url: '/segmentacao/resgatarativas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            $.each(r, function (key, value) {
                $('select[name=idseg]').append('<option value=' + value.idseg + '>' + value.descricao + '</option>');
            });
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
};

// popular lista de níveis ativos (usado para inserir ou editar usuario)
function PopularNiveis() {

    $.ajax({
        //url: 'http://localhost:9617/nivel/resgatarativos',
        url: '/nivel/resgatarativos',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            $.each(r, function (key, value) {
                $('select[name=idnivel]').append('<option value=' + value.idnivel + '>' + value.descricao + '</option>');
            });
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
};


$(document).ready(function () {

    Popular();
    PopularNiveis();
    PopularSegmentacoes();

    // ao clicar no botão de atualizar listagem de usuários
    $('#bt-refreshtable').on('click', function () {
        Popular();
    });

    // botão de cadastrar novo usuário
    $('#bt-open-cadform').on('click', function () {
        $('#cadform').show();
    });

    // fechar modal de cadastrar usuário
    $('#bt-close-cadform').on('click', function () {
        $('#cadform').hide();
    });

    // botão de editar usuário
    $('#table').on('click','.tb-editbtn', function () {
        var obj = table.row($(this).parent().parent()).data();

        $('#editform input[name=idusuario]').val(obj.idusuario);
        $('#editform input[name=login]').val(obj.login);
        $('#editform select[name=idnivel]').val(obj.idnivel);
        $('#editform select[name=idseg]').val(obj.idseg);
        $('#editform input[name=nome]').val(obj.nome);
        $('#editform input[name=email]').val(obj.email);

        if (obj.fativo === 'Ativo')
            $('#editform input[type=radio][name=ativo][value=true]').prop('checked', true);
        if (obj.fativo === 'Inativo')
            $('#editform input[type=radio][name=ativo][value=false]').prop('checked', true);

        $('#checkbox_resetsenha').prop('checked', false);
        $('#editform input[name=senha]').attr('disabled', true);

        $('#editform').show();
    });

    // fechar modal de editar usuário
    $('#bt-close-editform').on('click', function () {
        $('#editform').hide();
    });

    // opção de alterar ou não a senha do usuário (habilita/desabilita campo senha)
    $('#checkbox_resetsenha').on('change', function () {
        $('#editform input[name=senha]').attr('disabled', !this.checked);
    });

    // ao inserir usuário
    $('form[name=cadusuario]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/usuario/inserir',
            url: '/usuario/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#cadform').hide();
                $('form[name=cadusuario]')[0].reset();
                Popular();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // ao salvar alterações de usuário
    $('form[name=editusuario]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/usuario/editar',
            url: '/usuario/editar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#editform').hide();
                $('form[name=editusuario]')[0].reset();
                Popular();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

});



