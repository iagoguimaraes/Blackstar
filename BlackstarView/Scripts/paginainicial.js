

// resgata a sessao do usuário e popula os dados
function ResgatarSessao() {

    $.ajax({
        //url: 'http://localhost:9617/sessao/resgatar',
        url: '/sessao/resgatar',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        data: '',
        success: function (r) {
            PopularSessao(r);
        },
        error: function (err) {
            location.href = 'login.html'
        }
    });
}

function PopularSessao(sessao){
    $('#dtini').text(sessao.fdtini);
    $('#dtexp').text(sessao.fdtexp);
    $('#nome').text(sessao.usuario.nome);
    $('#nivel').text(sessao.usuario.nivel);
    $('#seg').text(sessao.usuario.segmentacao);
}

// quando o documento estiver carregado
$(document).ready(function () {
    ResgatarSessao();
});