
var table;

// popula listagem geral de ocorrências
function Popular() {

    table = $('#table').DataTable({
        destroy: true,
        ajax: {
            //url: 'http://localhost:9617/ocorrencia/resgatartodas',
            url: '/ocorrencia/resgatartodas',
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
                    { title: 'ID', data: 'idocor' },
                    { title: 'Ocorrência', data: 'descricao' },
                    { title: 'Classificação', data: 'classificacao' },
                    { title: 'Agendável', data: 'fagendavel' },
                    { title: 'Agendamento Padrão', data: 'agnd_padrao' },
                    { title: 'Máximo Agendamento', data: 'agnd_max' },
                    { title: 'Situação', data: 'fativo' },
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    { title: 'Carteira', data: 'carteira' },
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

// popula carteiras ativas (usado para inserir ou editar ocorrencias)
function PopularCarteiras() {

    $.ajax({
        //url: 'http://localhost:9617/carteira/resgatarativas',
        url: '/carteira/resgatarativas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            $.each(r, function (key, value) {
                $('select[name=idcart]').append('<option value=' + value.idcart + '>' + value.descricao + '</option>');
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
    PopularCarteiras();

    // botão atualizar listagem de ocorrencias
    $('#bt-refreshtable').on('click', function () {
        Popular();
    });

    // botão inserir nova ocorrencia
    $('#bt-open-cadform').on('click', function () {
        $('#cadform').show();
    });

    // fechar modal de inserir ocorrencia
    $('#bt-close-cadform').on('click', function () {
        $('#cadform').hide();
    });

    // botão de editar ocorrencia
    $('#table').on('click','.tb-editbtn', function () {
        var obj = table.row($(this).parent().parent()).data();

        $('#editform input[name=idocor]').val(obj.idocor);
        $('#editform input[name=descricao]').val(obj.descricao);
        $('#editform input[name=classificacao]').val(obj.classificacao);
        $('#editform [name=agendavel][value="' + obj.agendavel + '"]').prop('checked', true);
        $('#editform input[name=agnd_padrao]').val(obj.agnd_padrao);
        $('#editform input[name=agnd_max]').val(obj.agnd_max);
        $('#editform select[name=idcart]').val(obj.idcart);
        $('#editform [name=ativo][value="' + obj.ativo + '"]').prop('checked', true);

        $('#editform').show();
    });

    // fechar modal de editar ocorrencia
    $('#bt-close-editform').on('click', function () {
        $('#editform').hide();
    });

    // ao inserir nova ocorrencia
    $('form[name=cadocor]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/ocorrencia/inserir',
            url: '/ocorrencia/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#cadform').hide();
                $('form[name=cadocor]')[0].reset();
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

    // ao salvar alterações de ocorrencia
    $('form[name=editocor]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/ocorrencia/editar',
            url: '/ocorrencia/editar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#editform').hide();
                $('form[name=editocor]')[0].reset();
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


