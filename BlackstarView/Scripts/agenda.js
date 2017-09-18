
var locaisagendamento, // locais de agendamento que podem ser agendados
    tiposagendamento; // tipos de agendamento que podem ser agendados


// popula a listagem de carteiras (já aproveita e popula agendamentos, tipos e locais)
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

            PopularTudoAgendamento();

        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });

}

// popular os agendamentos
function PopularTudoAgendamento() {
    console.log('teste');
    ResgatarAgendamentos($('#ddl_cart').val());
}

// resgatar agendamentos de determinada carteira
function ResgatarAgendamentos(idcart) {
    $.ajax({
        //url: 'http://localhost:9617/agendamento/resgatar',
        url: '/agendamento/resgatar',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        data: '=' + idcart,
        success: function (agendamentos) {
            PopularAgendamentos(agendamentos);
            ResgatarLocaisAgendamento(idcart);
            ResgatarTiposAgendamento(idcart);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
}

// popula os agendamentos utlizando a api jqscheduler (estilo agenda/calendário) e também os ddl de inserir/editar agendamento
function PopularAgendamentos(agendamentos) {

    //#region jqscheduler

    // prepare the data
    var source =
    {
        dataType: "array",
        dataFields: [
            { name: 'idagendamento', type: 'string' },
            { name: 'descricao', type: 'string' },
            { name: 'local', type: 'string' },
            { name: 'descricaolocal', type: 'string' },
            { name: 'obs', type: 'string' },
            { name: 'usuario', type: 'string' },
            { name: 'cliente', type: 'string' },
            { name: 'fjsdtcad', type: 'date' },
            { name: 'fjsdtini', type: 'date' },
            { name: 'fjsdtfim', type: 'date' },
            { name: 'idtipoagendamento', type: 'int' },
            { name: 'idlocal', type: 'int' },
            { name: 'idcontrato', type: 'int' },
            { name: 'ativo', type: 'bool' },
        ],
        id: 'idagendamento',
        localData: agendamentos
    };
    var adapter = new $.jqx.dataAdapter(source);
    $("#scheduler").jqxScheduler({

        date: new $.jqx.date('todayDate'),
        source: adapter,
        view: 'weekView',
        //theme: 'shinyblack',
        showLegend: true,
        timeZone: 'E. South America Standard Time',
        ready: function () {
        },
        resources:
        {
            colorScheme: "scheme05",
            dataField: "local",
            source: new $.jqx.dataAdapter(source)
        },
        // campos dos eventos
        appointmentDataFields:
        {
            from: "fjsdtini",
            to: "fjsdtfim",
            id: "idagendamento",
            description: "obs",
            subject: "descricao",
            resource: "local",
            resourceId: "local",
            location: "cliente",
            usuario: "usuario",
            idagendamento: "idagendamento",
            idtipoagendamento: "idtipoagendamento",
            idlocal: "idlocal",
            obs: "obs",
            dtini: "fjsdtini",
            dtfim: "fjsdtfim",
            ativo: "ativo",
            cliente: "cliente",
            idcontrato: "idcontrato"
        },
        // modos de visualização
        views:
        [
        { type: 'dayView', timeRuler: { scale: 'hour', formatString: 'HH:mm' } },
        { type: 'weekView', timeRuler: { scale: 'hour', formatString: 'HH:mm' } },
        { type: 'monthView', timeRuler: { scale: 'hour', formatString: 'HH:mm' } },
        { type: 'agendaView', timeRuler: { scale: 'hour', formatString: 'HH:mm' } }

        ],
        // desabilitar criação
        contextMenu: false,
        editDialog: false,

        // ao mostrar detalhes do eventos
        editDialogCreate: function (dialog, fields, editAppointment) {
            fields.allDayContainer.hide();
            fields.timeZoneContainer.hide();
            fields.repeatContainer.hide();
            fields.colorContainer.hide();
            fields.statusContainer.hide();
        },
        editDialogOpen: function (dialog, fields, editAppointment) {
            console.log(fields);
            fields.repeatContainer.hide();
            if (editAppointment == null)
                fields.buttons.hide();
            else
                fields.buttons.show();
        },
        // editar linguagem
        localization: {
            days: {
                // full day names
                names: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado"],
                // abbreviated day names
                namesAbbr: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
                // shortest day names
                namesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"]
            },
            months: {
                // full month names (13 months for lunar calendards -- 13th month should be "" if not lunar)
                names: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro", ""],
                // abbreviated month names
                namesAbbr: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez", ""]
            },
            agendaViewString: "Agenda",
            agendaAllDayString: "O dia todo",
            agendaDateColumn: "Data",
            agendaTimeColumn: "Hora",
            agendaAppointmentColumn: "Agendamento",
            backString: "Voltar",
            forwardString: "Avançar",
            toolBarPreviousButtonString: "Anterior",
            toolBarNextButtonString: "Próximo",
            emptyDataString: "Nenhum registro encontrado",
            loadString: "Carregando...",
            clearString: "Limpar",
            todayString: "Hoje",
            dayViewString: "Dia",
            weekViewString: "Semana",
            monthViewString: "Mês",
            timelineDayViewString: "Timeline Dia",
            timelineWeekViewString: "Timeline Semana",
            timelineMonthViewString: "Timeline Mês"
        }
    });

    // ao clicar em um agendamento
    $('#scheduler').on('appointmentClick', function (event) {
        var appointment = event.args.appointment;

        $('form[name=editagendamento] input[name=idagendamento]').val(appointment.idagendamento);
        $('form[name=editagendamento] select[name=idtipoagendamento]').val(appointment.idtipoagendamento);
        $('form[name=editagendamento] select[name=idlocal]').val(appointment.idlocal);
        $('form[name=editagendamento] input[name=dtini]').val(formatarDateTime(appointment.dtini));
        $('form[name=editagendamento] input[name=dtfim]').val(formatarDateTime(appointment.dtfim));
        $('form[name=editagendamento] textarea[name=obs]').val(appointment.obs);
        $('form[name=editagendamento] input[name=usuario]').val(appointment.usuario);
        $('form[name=editagendamento] input[name=cliente]').val(appointment.cliente);
        $('#idcontrato_agnd').val(appointment.idcontrato)

        if (appointment.ativo)
            $('form[name=editagendamento] input[type=radio][name=ativo][value=true]').prop('checked', true);
        else
            $('form[name=editagendamento] input[type=radio][name=ativo][value=false]').prop('checked', true);

        $('.editform[name=agendamento]').show();

    });

    //#endregion

}

// resgatar os possiveis locais de agendamento
function ResgatarLocaisAgendamento(idcart) {
    $.ajax({
        //url: 'http://localhost:9617/agendamento/resgatarlocais',
        url: '/agendamento/resgatarlocais',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        data: '=' + idcart,
        success: function (r) {
            locaisagendamento = r;
            PopularLocaisAgendamento(r);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
}

// popular os ddl de locais de agendamento
function PopularLocaisAgendamento(locaisagendamento) {
    // Popula a DDL de inserir/editar agendamento [locais de agendamento]
    var $ddl_localagendamento = $('select[name=idlocal]');
    $ddl_localagendamento.empty();
    $ddl_localagendamento.append('<option value="">Selecione</option>');
    $.each(locaisagendamento, function (n, localagend) {
        var $op = $('<option>');
        $op.val(localagend.idlocal).text(localagend.nome);
        $ddl_localagendamento.append($op);
    });
}

// resgatar os possiveis tipos de agendamento
function ResgatarTiposAgendamento(idcart) {
    $.ajax({
        //url: 'http://localhost:9617/agendamento/resgatartipos',
        url: '/agendamento/resgatartipos',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        data: '=' + idcart,
        success: function (r) {
            tiposagendamento = r;
            PopularTiposAgendamento(r);
        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
}

// popular os ddl de tipos de agendamento
function PopularTiposAgendamento(tiposagendamento) {
    // Popula a DDL de inserir/editar agendamento [tipos de agendamento]
    var $ddl_tipoagendamento = $('select[name=idtipoagendamento]');
    $ddl_tipoagendamento.empty();
    $ddl_tipoagendamento.append('<option value="">Selecione</option>');
    $.each(tiposagendamento, function (n, tipoagend) {
        var $op = $('<option>');
        $op.val(tipoagend.idtipoagendamento).text(tipoagend.descricao);
        $ddl_tipoagendamento.append($op);
    });
}

// função para completar com 0 na frente
function pad(n, width, z) {
    z = z || '0';
    n = n + '';
    return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
}

// função para formatar datetime no formato do input datetime
function formatarDateTime(date) {
    return [pad(date.getFullYear(), 4),
            pad((date.getMonth() + 1), 2),
            pad(date.getDate(), 2)].join('/') + ' ' +
          [pad(date.getHours(), 2),
           pad(date.getMinutes(), 2)].join(':');
}

$(document).ready(function () {

    // Popular a ficha
    PopularCarteiras();

    // botão de atualizar ficha
    $('#bt-refresh').on('click', function () {
        PopularTudoAgendamento();
    });

    // ao mudar de carteira popula os agends
    $('#ddl_cart').change(function () {
        PopularTudoAgendamento();
    });

    // ao clicar no botão de fechar a modal de edição
    $('.bt-close-editform').on('click', function () {
        $('.editform').hide();
    });

    // ao clicar no botão de esconder o form
    $('.hide-form').on('click', function () {
        $form = $(this).parent().parent();
        $fields = $form.find('.formulario-campo');
        console.log($fields.eq(0).css('display'));
        if ($fields.eq(0).css('display') == 'none')
            $fields.show();
        else
            $fields.hide();
    });

    // inputs de datetime
    $('.datetimepicker').datetimepicker({
        //format: 'd/m/Y H:i',
        lang: 'pt-BR'
    });

    // previnir volta de página no backspace
    $(document).keydown(function (e) {
        if (e.which === 8 && !$(e.target).is("input, textarea")) {
            e.preventDefault();
        }
    });

    //#region Eventos de Agendamento

    // ao clicar no botão de editar agendamento
    $('form[name=editagendamento]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/agendamento/editar',
            url: '/agendamento/editar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                $('.editform[name=agendamento]').hide();
                $('form[name=editagendamento]')[0].reset();
                PopularAgendamentos();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });

    });

    //ao clicar para acessar o contrato do agendamento
    $('#agend_acessarficha').on('click', function () {
        // obtém o idcontrato
        var idcontrato = $('#idcontrato_agnd').val();
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

    //#endregion

});