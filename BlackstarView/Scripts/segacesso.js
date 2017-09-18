
// Popula o select com todos os níveis ativos cadastrados no sistema
function PopularDDLSegmentacoes() {
    $.ajax({
        //url: 'http://localhost:9617/segmentacao/resgatarativas',
        url: '/segmentacao/resgatarativas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            $.each(r, function (n, seg) {

                $op = $('<option>');
                $op.val(seg.idseg);
                $op.text(seg.descricao);

                $('#dll_seg').append($op);
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

// Popula a listagem de checkbox com todas as cariteras ativas do sistema
function PopularListaCarteiras() {

    $.ajax({
        //url: 'http://localhost:9617/carteira/resgatartodas',
        url: '/carteira/resgatartodas',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            $.each(r, function (n, carteira) {

                $item = $('<li><input type="checkbox" name="carteira" value="' + carteira.idcart + '">' + carteira.descricao + '</li>');
                $('#list_acessocarteira').append($item);
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

// Verifica quais carteiras a segmentação tem acesso e marca/desmarca os checkbox de carteiras
function VerificarAcessoCarteiras(idseg) {

    $.ajax({
        //url: 'http://localhost:9617/acessocarteira/resgatar',
        url: '/acessocarteira/resgatar',
        type: 'POST',
        data: '=' + idseg,
        headers: { 'token': sessionStorage.getItem('token') },
        success: function (r) {

            // primeiro desabilita todos
            $('input[type=checkbox][name=carteira]').prop('checked', false);

            $.each(r, function (n, carteira) {
                $('input[type=checkbox][name=carteira][value=' + carteira.idcart + ']').prop('checked', true);
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

function HabilitarCarteira(idcart, idseg) {

    $.ajax({
        //url: 'http://localhost:9617/acessocarteira/inserir',
        url: '/acessocarteira/inserir',
        type: 'POST',
        data: { 'idcart': idcart, 'idseg': idseg },
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

function DesabilitarCarteira(idcart, idseg) {

    $.ajax({
        //url: 'http://localhost:9617/acessocarteira/remover',
        url: '/acessocarteira/remover',
        type: 'POST',
        data: { 'idcart': idcart, 'idseg': idseg },
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

// quando o documento estiver pronto: popular ddl segmentações e lista de carteiras
$(document).ready(function () {

    PopularDDLSegmentacoes();
    PopularListaCarteiras();

    //ao selecionar uma segmentação, verificar quais acessos ela possui
    $('#dll_seg').on('change', function () {
        VerificarAcessoCarteiras($(this).val());
    });

    // ao marcar/desmarcar acesso a carteira
    $('#list_acessocarteira').on('change', 'input[type=checkbox]', function () {
        var idcart = $(this).val();
        var idseg = $('#dll_seg').val();
        var marcado = $(this).prop('checked');

        if (idseg != '-1') {
            if (marcado)
                HabilitarCarteira(idcart, idseg);
            else
                DesabilitarCarteira(idcart, idseg);
        }
    });

});





