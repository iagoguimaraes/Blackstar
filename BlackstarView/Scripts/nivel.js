
var table;

// popular listagem de níveis
function Popular() {

    table = $('#table').DataTable({
        destroy: true,
        ajax: {
            //url: 'http://localhost:9617/nivel/resgatartodos',
            url: '/nivel/resgatartodos',
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
                    { title: 'ID', data: 'idnivel' },
                    { title: 'Nível', data: 'descricao' },
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

$(document).ready(function () {

    Popular();

    // atualizar listagem de níveis
    $('#bt-refreshtable').on('click', function () {
        Popular();
    });

    // botão de cadastrar novo nível
    $('#bt-open-cadform').on('click', function () {
        $('#cadform').show();
    });

    // fechar modal de cadastrar novo nível
    $('#bt-close-cadform').on('click', function () {
        $('#cadform').hide();
    });

    // botão de editar nível
    $('#table').on('click', '.tb-editbtn', function () {
        var obj = table.row($(this).parent().parent()).data();

        $('#editform input[name=idnivel]').val(obj.idnivel);
        $('#editform input[name=descricao]').val(obj.descricao);

        if (obj.fativo === 'Ativo')
            $('#editform input[type=radio][name=ativo][value=true]').prop('checked', true);
        if (obj.fativo === 'Inativo')
            $('#editform input[type=radio][name=ativo][value=false]').prop('checked', true);

        $('#editform').show();
    });

    // fechar modal de editar nível
    $('#bt-close-editform').on('click', function () {
        $('#editform').hide();
    });

    // ao cadastrar novo nível
    $('form[name=cadnivel]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/nivel/inserir',
            url: '/nivel/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#cadform').hide();
                $('form[name=cadnivel]')[0].reset();
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

    // ao salvar alterações de nível
    $('form[name=editnivel]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/nivel/editar',
            url: '/nivel/editar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#editform').hide();
                $('form[name=editnivel]')[0].reset();
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



