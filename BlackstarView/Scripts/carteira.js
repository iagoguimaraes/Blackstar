
var table;

// popula a listagem geral de carteiras
function Popular() {

    table = $('#table').DataTable({
        destroy: true,
        ajax: {
            //url: 'http://localhost:9617/carteira/resgatartodas',
            url: '/carteira/resgatartodas',
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
                    { title: 'ID', data: 'idcart' },
                    { title: 'Carteira', data: 'descricao' },
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    { title: 'Situação', data: 'fativo' },
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

// quando o documento estiver pronto
$(document).ready(function () {

    Popular();

    // ao clicar no botão de atualizar a listagem
    $('#bt-refreshtable').on('click', function () {
        Popular();
    });

    // ao clicar no botão para inserir nova carteira
    $('#bt-open-cadform').on('click', function () {
        $('#cadform').show();
    });

    // ao clicar no botão de fechar a modal de inserir nova carteira
    $('#bt-close-cadform').on('click', function () {
        $('#cadform').hide();
    });

    // ao clicar no botão de editar determinada carteira
    $('#table').on('click','.tb-editbtn', function () {
        var obj = table.row($(this).parent().parent()).data();

        $('#editform input[name=idcart]').val(obj.idcart);
        $('#editform input[name=descricao]').val(obj.descricao);

        if (obj.fativo === 'Ativo')
            $('#editform input[type=radio][name=ativo][value=true]').prop('checked', true);
        if (obj.fativo === 'Inativo')
            $('#editform input[type=radio][name=ativo][value=false]').prop('checked', true);

        $('#editform').show();
    });

    // ao clicar no botão de fechar o modal de edição de carteira
    $('#bt-close-editform').on('click', function () {
        $('#editform').hide();
    });

    // ao clicar no botão de cadastrar nova carteira
    $('form[name=cadcart]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/carteira/inserir',
            url: '/carteira/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#cadform').hide();
                $('form[name=cadcart]')[0].reset();
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

    // ao clicar no botão de salvar alterações da carteira (editar)
    $('form[name=editcart]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/carteira/editar',
            url: '/carteira/editar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#editform').hide();
                $('form[name=editcart]')[0].reset();
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



