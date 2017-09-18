
var sessao;

// quando o documento estiver carregado
$(document).ready(function () {
    ResgatarSessao();

    AbrirPagina('paginainicial.html');
});

// ao clicar em abrir menu
$(document).on('click', '#open-menu', function () {
    $('#menu').show('slow');
});

// ao clicar em fechar o menu
$(document).on('click', '#close-menu', function () {
    $('#menu').hide('slow');
});

// ao clicar fora do menu (fechar menu)
$(document).click(function (event) {
    if (!$(event.target).is('#menu, #open-menu, #close-menu')) {
        $('#menu').hide('slow');
    }
});

// ao clicar em um item do menu (abrir pagina)
$(document).on('click', '.menu-item', function () {

    // resgata qual url vai abrir
    var url = $(this).data('url');

    // resgata o nome da página
    var nome = $(this).data('nome');

    AbrirPagina(url);
});

// previnir volta de página no backspace
$(document).keydown(function (e) {
    if (e.which === 8 && !$(e.target).is("input, textarea")) {
        e.preventDefault();
    }
});

// resgata a sessao do usuário ou retorna para pagina de login
function ResgatarSessao() {

    // se o usuário não estiver autenticado, retornar a página de login
    if (!sessionStorage.getItem('token'))
        location.href = 'login.html'
    else {
        $.ajax({
            //url: 'http://localhost:9617/sessao/resgatar',
            url: '/sessao/resgatar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '',
            success: function (r) {
                sessao = r;
                PopularMenu(r.menu);
            },
            error: function (err) {
                location.href = 'login.html'
            }
        });
    }
}

// popula os itens do menu
function PopularMenu(menu) {
    // ordena o menu
    menu = menu.sort(menu.ordenacao).reverse();
    // faz um loop na listagem de itens do menu
    for (key in menu) {
        var item = menu[key];
        // cria os elementos html
        $item = $('<div class="menu-item" data-url="' + item.url + '" data-nome="' + item.descricao + '">');
        $icon = $('<i class="material-icons menu-item-icon">' + item.icone + '</i>');
        $text = $('<div class="menu-item-text">' + item.descricao + '</div>');
        $item.append($icon).append($text);
        // insere no documento (no menu)
        $('#menu-list-item').prepend($item);
    }
}

// abrir uma pagina no pagecontent
function AbrirPagina(url) {
    // limpa o conteúdo
    $('#pagecontent').empty();

    // carrega a página
    $.ajax({
        url: url,
        cache: false,
        dataType: "html",
        success: function (data) {
            $("#pagecontent").html(data);
        }
    });
}