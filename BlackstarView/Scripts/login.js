
$(document).on('submit', 'form[name=login]', function (event) {
    event.preventDefault();

    $.ajax({
        //url: 'http://localhost:9617/sessao/gerartoken',
        url: '/sessao/gerartoken',
        type: 'POST',
        data: $(this).serialize(),
        success: function (token) {
            sessionStorage.setItem('token', token);
            location.href = 'blackstar.html';
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
})