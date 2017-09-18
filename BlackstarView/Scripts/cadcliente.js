
// popula a listagem de carteiras
function PopularCarteiras() {

    $.ajax({
        //url: 'http://localhost:9617/carteira/resgatarminhas',
        url: '/carteira/resgatarminhas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            $.each(r, function (n, carteira) {

                $op = $('<option name="carteira" value="' + carteira.idcart + '">' + carteira.descricao + '</option>');
                $('#ddl_cart').append($op);
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

// Se cadastrar com sucesso, acessa a ficha do cliente
function AcessarFicha(idcontrato) {

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

}

// ao carregar documento
$(document).ready(function () {

    // popular o dll de carteiras
    PopularCarteiras();

    // ao clicar no botão de cadastrar novo contrato
    $('form[name=cadcon]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/contrato/inserir',
            url: '/contrato/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                AcessarFicha(r);
                $('form[name=cadcon]')[0].reset();
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