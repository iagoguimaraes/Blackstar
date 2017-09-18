
var table;

// popular a listagem de contratos
function Popular(dados) {
    table = $('#table').DataTable({
        destroy: true,
        ajax: {
            //url: 'http://localhost:9617/contrato/buscar',
            url: '/contrato/buscar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            dataSrc: '',
            data: function (d) { return dados; },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        },
        columns: [
                    { title: 'CPF', data: 'cpf' },
                    { title: 'Nome', data: 'nome' },
                    { title: 'Contrato', data: 'numero' },
                    { title: 'Sequencial', data: 'sq' },
                    { title: 'Carteira', data: 'carteira' },
                    {
                        title: 'Acessar', data: null, orderable: false,
                        render: function (data, type) {
                            return '<i class="material-icons tb-acessbtn" title="Acessar">search</i>'
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

    // ao clicar no botão de pesquisar
    $('form[name=acionamento]').on('submit', function (event) {
        event.preventDefault();
        Popular($(this).serialize());
    });

    // ao clicar no botão de acessar o contrato
    $('#table').on('click', '.tb-acessbtn', function () {

        // resgata o id do contrato
        var obj = table.row($(this).parent().parent()).data();
        var idcontrato = obj.idcontrato;

        // armazena o id na session
        sessionStorage.setItem('ficha', idcontrato);

        // limpa o conteúdo
        $('#pagecontent').empty();

        // carrega a página da ficha
        $.ajax({
            url: 'ficha.html',
            cache: false,
            dataType: "html",
            success: function (data) {
                $("#pagecontent").html(data);
            }
        });

    });

});

