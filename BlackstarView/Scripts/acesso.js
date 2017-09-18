
// Popula o select com todos os níveis ativos cadastrados no sistema
function PopularDDLNiveis() {
    $.ajax({
        // url: 'http://localhost:9617/nivel/resgatarativos',
        url: '/nivel/resgatarativos',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            $.each(r, function (n, nivel) {

                $op = $('<option>')
                $op.val(nivel.idnivel);
                $op.text(nivel.descricao);

                $('#dll_nivel').append($op);
            });
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
}

// Popula a listagem de checkbox com todas as páginas do sistema
function PopularListaPaginas() {

    $.ajax({
        // url: 'http://localhost:9617/pagina/resgatartodas',
        url: '/pagina/resgatartodas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            $.each(r, function (n, pagina) {

                $item = $('<li><input type="checkbox" name="pagina" value="' + pagina.idpagina + '">' + pagina.descricao + '</li>');
                $('#list_acessopagina').append($item);
            });

        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

// Popula a listagem de checkbox com todas as funções do sistema
function PopularListaFuncoes() {

    $.ajax({
        //url: 'http://localhost:9617/funcao/resgatartodas',
        url: '/funcao/resgatartodas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            // separa a listagem de funções pelo tipo (inserir, resgatar, remover, etc..)
            var agrupado = GroupBy(r, 'tipo');

            // faz um loop em todas as funções e adiciona no DOM
            for (tipo in agrupado) {

                $('#list_acessofuncao').append('<p>' + tipo.toUpperCase() + '</p>');

                var funcoes = agrupado[tipo];

                for (n in funcoes) {
                    var funcao = funcoes[n];

                    $item = $('<li><input type="checkbox" name="funcao" value="' + funcao.idfuncao + '">' + funcao.descricao + '</li>');
                    $('#list_acessofuncao').append($item);
                }

            }

            //// Inserir TUDO sem separar por tipo
            //$.each(r, function (n, funcao) {

            //    $item = $('<li><input type="checkbox" name="funcao" value="' + funcao.idfuncao + '">' + funcao.descricao + '</li>');
            //    $('#list_acessofuncao').append($item);
            //});

        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

// Verifica quais acessos o nível tem e marca/desmarca os checkbox de páginas
function VerificarAcessoPaginas(idnivel) {

    $.ajax({
        //url: 'http://localhost:9617/acessopagina/resgatar',
        url: '/acessopagina/resgatar',
        type: 'POST',
        data: '=' + idnivel,
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            // primeiro desabilita todos
            $('input[type=checkbox][name=pagina]').prop('checked', false);

            $.each(r, function (n, pagina) {
                $('input[type=checkbox][name=pagina][value=' + pagina.idpagina + ']').prop('checked', true);
            });

        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

// Verifica quais acessos o nível tem e marca/desmarca os checkbox de funções
function VerificarAcessosFuncoes(idnivel) {



    $.ajax({
        //url: 'http://localhost:9617/acessofuncao/resgatar',
        url: '/acessofuncao/resgatar',
        type: 'POST',
        data: '=' + idnivel,
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            // primeiro desabilita todos
            $('input[type=checkbox][name=funcao]').prop('checked', false);

            $.each(r, function (n, funcao) {
                $('input[type=checkbox][name=funcao][value=' + funcao.idfuncao + ']').prop('checked', true);
            });

        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

function HabilitarFuncao(idfuncao, idnivel) {

    $.ajax({
        //url: 'http://localhost:9617/acessofuncao/inserir',
        url: '/acessofuncao/inserir',
        type: 'POST',
        data: { 'idfuncao': idfuncao, 'idnivel': idnivel },
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            console.log(r);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

function DesabilitarFuncao(idfuncao, idnivel) {

    $.ajax({
        //url: 'http://localhost:9617/acessofuncao/remover',
        url: '/acessofuncao/remover',
        type: 'POST',
        data: { 'idfuncao': idfuncao, 'idnivel': idnivel },
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            console.log(r);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

function HabilitarPagina(idpagina, idnivel) {

    $.ajax({
        //url: 'http://localhost:9617/acessopagina/inserir',
        url: '/acessopagina/inserir',
        type: 'POST',
        data: { 'idpagina': idpagina, 'idnivel': idnivel },
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            console.log(r);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

function DesabilitarPagina(idpagina, idnivel) {

    $.ajax({
        //url: 'http://localhost:9617/acessopagina/remover',
        url: '/acessopagina/remover',
        type: 'POST',
        data: { 'idpagina': idpagina, 'idnivel': idnivel },
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {
            console.log(r);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

// função para agrupar um array por determinado campo
function GroupBy(array, campo) {

    agrupado = [];

    for (key in array) {

        var value = array[key];

        if (!agrupado[value[campo]])
            agrupado[value[campo]] = [];

        agrupado[value[campo]].push(value);
    }

    return agrupado;
}

// quando o documento estiver pronto: popular ddl niveis, lista de paginas e funcoes
$(document).ready(function () {

    PopularDDLNiveis();
    PopularListaPaginas();
    PopularListaFuncoes();

    //ao selecionar um nível, verificar quais acessos ele possui
    $('#dll_nivel').on('change', function () {
        VerificarAcessoPaginas($(this).val());
        VerificarAcessosFuncoes($(this).val());
    });

    // ao marcar/desmarcar acesso a pagina
    $('#list_acessopagina').on('change', 'input[type=checkbox]', function () {
        var idpagina = $(this).val();
        var idnivel = $('#dll_nivel').val();
        var marcado = $(this).prop('checked');

        if (idnivel != '-1') {
            if (marcado)
                HabilitarPagina(idpagina, idnivel);
            else
                DesabilitarPagina(idpagina, idnivel);
        }
    });

    // ao marcar/desmarcar acesso a funcao
    $('#list_acessofuncao').on('change', 'input[type=checkbox]', function () {
        var idfuncao = $(this).val();
        var idnivel = $('#dll_nivel').val();
        var marcado = $(this).prop('checked');

        if (idnivel != '-1') {
            if (marcado)
                HabilitarFuncao(idfuncao, idnivel);
            else
                DesabilitarFuncao(idfuncao, idnivel);
        }
    });

});





