
var table;

// popular listagem de segmentações
function Popular() {

    table = $('#table').DataTable({
        destroy: true,
        ajax: {
            //url: 'http://localhost:9617/segmentacao/resgatartodas',
            url: '/segmentacao/resgatartodas',
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
                    { title: 'ID', data: 'idseg' },
                    { title: 'Segmentação', data: 'descricao' },
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

    // atualizar listagem de segmentações
    $('#bt-refreshtable').on('click', function () {
        Popular();
    });

    // botão cadastrar nova segmentação
    $('#bt-open-cadform').on('click', function () {
        $('#cadform').show();
    });

    // fechar modal de cadastrar nova segmentação
    $('#bt-close-cadform').on('click', function () {
        $('#cadform').hide();
    });

    // botão editar segmentação
    $('#table').on('click','.tb-editbtn', function () {
        var obj = table.row($(this).parent().parent()).data();

        $('#editform input[name=idseg]').val(obj.idseg);
        $('#editform input[name=descricao]').val(obj.descricao);

        if (obj.fativo === 'Ativa')
            $('#editform input[type=radio][name=ativo][value=true]').prop('checked', true);
        if (obj.fativo === 'Inativa')
            $('#editform input[type=radio][name=ativo][value=false]').prop('checked', true);

        $('#editform').show();
    });

    // fechar modal de editar segmentação
    $('#bt-close-editform').on('click', function () {
        $('#editform').hide();
    });

    // ao inserir nova segmentação
    $('form[name=cadseg]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/segmentacao/inserir',
            url: '/segmentacao/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#cadform').hide();
                $('form[name=cadseg]')[0].reset();
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

    // ao salvar alterações de uma segmentação
    $('form[name=editseg]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/segmentacao/editar',
            url: '/segmentacao/editar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                alert(r);
                $('#editform').hide();
                $('form[name=editseg]')[0].reset();
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


