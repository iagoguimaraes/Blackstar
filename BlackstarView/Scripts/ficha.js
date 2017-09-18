
var qualificacoes, // listagem de todas as qualificações de telefone (usado para qualificar os telefones)
    tabletel, // tabela de telefones
    tableend, // tabela de endereços
    tablemail, // tabela de emails
    ocorrencias, // listagem de todas as ocorrências possíveis para tabular
    tabletab, // tabela de tabulacoes
    agendamentos, // lista de todos os agendamentos que a carteira possui
    tiposagendamento, // tipos de agendamento que podem ser agendados
    locaisagendamento; // locais de agendamento que podem ser agendados

// popular os dados do contrato
function PopularFicha() {

    // resgata qual é o id do contrato
    var idcontrato = sessionStorage.getItem('ficha');

    $.ajax({
        //url: 'http://localhost:9617/contrato/ficha',
        url: '/contrato/ficha',
        type: 'POST',
        headers: { 'token': sessionStorage.getItem('token') },
        data: '=' + idcontrato,
        success: function (ficha) {
            console.log(ficha);

            PopularDados(ficha.contrato);
            qualificacoes = ficha.qualificacoes;
            PopularTabelaTelefones(ficha.telefones);
            PopularTabelaEnderecos(ficha.enderecos);
            PopularTabelaEmails(ficha.emails);
            ocorrencias = ficha.ocorrencias;
            PopularTabelaTabulacoes(ficha.tabulacoes);
            tiposagendamento = ficha.tiposagendamento;
            locaisagendamento = ficha.locaisagendamento;
            PopularAgendamentos(ficha.agendamentos);

        },
        error: function (err) {
            if (err.status === 400)
                alert(err.responseText);
            else
                alert('Erro ao conectar com o servidor');
        }
    });
}

// popular dados referente ao contrato
function PopularDados(contrato) {
    // popula todos os campos da ficha
    $('.contrato-info').each(function () {
        var prop = $(this).attr('name');
        $(this).text(contrato[prop]);
    });
    // popula os hidden com o idcontrato
    $('input[name=idcontrato]').val(contrato.idcontrato);
}

// retorna um ddl com as possível qualificacoes e o com o id passado como parâmetro selecionado
function PopularDDLQualificacao(idqualificacao) {
    var $qualificacoes = $('<select class="qualificacao">');
    $qualificacoes.append('<option value="0">Selecione</option>');
    $.each(qualificacoes, function (n, qualificacao) {
        var $op = $('<option>');
        $op.val(qualificacao.idqualificacao).text(qualificacao.descricao);
        if (qualificacao.idqualificacao == idqualificacao)
            $op.attr("selected", "selected");
        $qualificacoes.append($op);
    });
    return $qualificacoes.prop('outerHTML');
}

// popula a listagem geral de telefones (e também o ddl de inserir tabulação)
function PopularTabelaTelefones(telefones) {

    tabletel = $('#table-tel').DataTable({
        destroy: true,
        data: telefones,
        columns: [
                    { title: 'Telefone', data: 'ftelefone' },
                    { title: 'Tipo', data: 'tipo' },
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    {
                        title: 'Preferêncial', data: null, orderable: false,
                        render: function (data, type) {
                            if (data.preferencial == 1)
                                return '<i class="material-icons tb-icon bt-npref" title="marcar como não preferencial">star</i>';
                            else
                                return '<i class="material-icons tb-icon bt-pref" title="marcar como preferencial">star_border</i>';
                        }
                    },
                    {
                        title: 'Ativo', data: null, orderable: false,
                        render: function (data, type) {
                            if (data.ativo == 1)
                                return '<i class="material-icons tb-icon bt-inativa" title="inativar telefone">check_box</i>';
                            else
                                return '<i class="material-icons tb-icon bt-reativa" title="reativar telefone">check_box_outline_blank</i>';
                        }
                    },
                    {
                        title: 'Qualificação', data: null, orderable: false,
                        render: function (data, type) {
                            return PopularDDLQualificacao(data.idqualificacao);
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

    // Popula a DDL de inserir tabulação com os telefones
    var $ddl_tel = $('form[name=cadtab] select[name=idtel]');
    $ddl_tel.empty();
    $ddl_tel.append('<option value="0">Selecione</option>');
    $.each(telefones, function (n, telefone) {
        var $op = $('<option>');
        $op.val(telefone.idtel).text(telefone.ftelefone);
        $ddl_tel.append($op);
    });

}

// popula a listagem geral de endereços (e também o ddl de inserir tabulação)
function PopularTabelaEnderecos(enderecos) {

    tableend = $('#table-end').DataTable({
        destroy: true,
        data: enderecos,
        columns: [
                    { title: 'CEP', data: 'fcep' },
                    { title: 'Logradouro', data: 'logradouro' },
                    { title: 'Número', data: 'numero' },
                    { title: 'Bairro', data: 'bairro' },
                    { title: 'Cidade', data: 'cidade' },
                    { title: 'UF', data: 'uf' },
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    {
                        title: 'Preferêncial', data: null, orderable: false,
                        render: function (data, type) {
                            if (data.preferencial == 1)
                                return '<i class="material-icons tb-icon bt-npref" title="marcar como não preferencial">star</i>';
                            else
                                return '<i class="material-icons tb-icon bt-pref" title="marcar como preferencial">star_border</i>';
                        }
                    },
                    {
                        title: 'Ativo', data: null, orderable: false,
                        render: function (data, type) {
                            if (data.ativo == 1)
                                return '<i class="material-icons tb-icon bt-inativa" title="inativar endereço">check_box</i>';
                            else
                                return '<i class="material-icons tb-icon bt-reativa" title="reativar endereço">check_box_outline_blank</i>';
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

    // Popula a DDL de inserir tabulação com os endereços
    var $ddl_end = $('form[name=cadtab] select[name=idend]');
    $ddl_end.empty();
    $ddl_end.append('<option value="0">Selecione</option>');
    $.each(enderecos, function (n, endereco) {
        var $op = $('<option>');
        $op.val(endereco.idend).text(endereco.logradouro);
        $ddl_end.append($op);
    });
}

// popula a listagem geral de e-mails (e também o ddl de inserir tabulação)
function PopularTabelaEmails(emails) {

    tablemail = $('#table-mail').DataTable({
        destroy: true,
        data: emails,
        columns: [
                    { title: 'Email', data: 'email' },
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    {
                        title: 'Preferêncial', data: null, orderable: false,
                        render: function (data, type) {
                            if (data.preferencial == 1)
                                return '<i class="material-icons tb-icon bt-npref" title="marcar como não preferencial">star</i>';
                            else
                                return '<i class="material-icons tb-icon bt-pref" title="marcar como preferencial">star_border</i>';
                        }
                    },
                    {
                        title: 'Ativo', data: null, orderable: false,
                        render: function (data, type) {
                            if (data.ativo == 1)
                                return '<i class="material-icons tb-icon bt-inativa" title="inativar email">check_box</i>';
                            else
                                return '<i class="material-icons tb-icon bt-reativa" title="reativar email">check_box_outline_blank</i>';
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

    // Popula a DDL de inserir tabulação com os emails
    var $ddl_mail = $('form[name=cadtab] select[name=idmail]');
    $ddl_mail.empty();
    $ddl_mail.append('<option value="0">Selecione</option>');
    $.each(emails, function (n, email) {
        var $op = $('<option>');
        $op.val(email.idmail).text(email.email);
        $ddl_mail.append($op);
    });

}

// popula a listagem geral de tabulações
function PopularTabelaTabulacoes(tabulacoes) {

    tabletab = $('#table-tab').DataTable({
        destroy: true,
        data: tabulacoes,
        columns: [
                    { title: 'Data Cadastro', data: 'fdtcad' },
                    { title: 'Data Agendamento', data: 'fdtagend' },
                    { title: 'Ocorrência', data: 'descricao' },
                    { title: 'Classificação', data: 'classificacao' },
                    { title: 'Analista', data: 'nome' },
                    { title: 'Descrição', data: 'obs' },
                    { title: 'Telefone', data: 'ftelefone' },
                    { title: 'Endereço', data: 'logradouro' },
                    { title: 'Email', data: 'email' }
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

    //popula também as ocorrencias que podem ser tabuladas no cadastro de tabulação
    var $ocorrencias = $('form[name=cadtab] select[name=idocor]');
    $ocorrencias.empty();
    $ocorrencias.append('<option value="">Selecione</option>');
    $.each(ocorrencias, function (n, ocorrencia) {
        var $op = $('<option>');
        $op.val(ocorrencia.idocor).text(ocorrencia.descricao);
        $ocorrencias.append($op);
    });
}

// função para encontrar um objeto em um array pelo nome de umas das suas propriedades
function findObjOnArray(findString, propertyName, array) {
    for (var i = 0, len = array.length; i < len; i++) {
        var obj = array[i];
        if (obj[propertyName] == findString)
            return obj;
    }
    return null;
}

// função para formatar datetime no formato do input datetime
function formatarDateTime(date) {
    return [pad(date.getFullYear(), 4),
            pad((date.getMonth() + 1), 2),
            pad(date.getDate(), 2)].join('/') + ' ' +
          [pad(date.getHours(), 2),
           pad(date.getMinutes(), 2)].join(':');
}

// função para completar com 0 na frente
function pad(n, width, z) {
    z = z || '0';
    n = n + '';
    return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
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

    // Popula a DDL de inserir/editar agendamento [tipos de agendamento]
    var $ddl_tipoagendamento = $('select[name=idtipoagendamento]');
    $ddl_tipoagendamento.empty();
    $ddl_tipoagendamento.append('<option value="">Selecione</option>');
    $.each(tiposagendamento, function (n, tipoagend) {
        var $op = $('<option>');
        $op.val(tipoagend.idtipoagendamento).text(tipoagend.descricao);
        $ddl_tipoagendamento.append($op);
    });

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

$(document).ready(function () {

    // formatar data nos datatables
    $.fn.dataTable.moment('DD/MM/YYYY HH:mm');

    // Popular a ficha
    PopularFicha();

    // botão de atualizar ficha
    $('#bt-refreshficha').on('click', function () {
        PopularFicha();
    });

    // botão de atualizar ficha
    $('#bt-backacionamento').on('click', function () {
        // limpa o conteúdo
        $('#pagecontent').empty();

        // carrega a página da ficha
        $.ajax({
            url: 'acionamento.html',
            cache: false,
            dataType: "html",
            success: function (data) {
                $("#pagecontent").html(data);
            }
        });
    });

    // ao clicar no botão de fechar a modal de cadastro
    $('.bt-close-cadform').on('click', function () {
        $('.cadform').hide();
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

    //#region Eventos Telefone

    // ao clicar no botão para adicionar novo telefone (abrir modal)
    $('#bt-addtel').on('click', function () {
        $('.cadform[name=tel]').show();
    });

    // ao clicar no botão de cadastrar nova telefone
    $('form[name=cadtel]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/telefone/inserir',
            url: '/telefone/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                $('.cadform[name=tel]').hide();
                $('form[name=cadtel]')[0].reset();
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });

    });

    // botão de reativar telefone
    $('#table-tel').on('click', '.bt-reativa', function () {
        var obj = tabletel.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/telefone/reativar',
            url: '/telefone/reativar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idtel,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de inativar telefone
    $('#table-tel').on('click', '.bt-inativa', function () {
        var obj = tabletel.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/telefone/inativar',
            url: '/telefone/inativar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idtel,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de marcar telefone como preferencial
    $('#table-tel').on('click', '.bt-pref', function () {
        var obj = tabletel.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/telefone/preferencial',
            url: '/telefone/preferencial',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idtel,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de marcar telefone como não preferencial
    $('#table-tel').on('click', '.bt-npref', function () {
        var obj = tabletel.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/telefone/naopreferencial',
            url: '/telefone/naopreferencial',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idtel,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // mudar a qualificação do telefone
    $('#table-tel').on('change', '.qualificacao', function () {
        var obj = tabletel.row($(this).parent().parent()).data();
        var idqualificacao = $(this).val();
        $.ajax({
            //url: 'http://localhost:9617/telefone/qualificar',
            url: '/telefone/qualificar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: { 'idtel': obj.idtel, 'idqualificacao': idqualificacao },
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    //#endregion

    //#region Eventos Endereço

    // ao clicar no botão para adicionar novo endereço (abrir modal)
    $('#bt-addend').on('click', function () {
        $('.cadform[name=end]').show();
    });

    // ao clicar no botão de cadastrar nova endereço
    $('form[name=cadend]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/endereco/inserir',
            url: '/endereco/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                $('.cadform[name=end]').hide();
                $('form[name=cadend]')[0].reset();
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });

    });

    // botão de reativar endereço
    $('#table-end').on('click', '.bt-reativa', function () {
        var obj = tableend.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/endereco/reativar',
            url: '/endereco/reativar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idend,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de inativar endereço
    $('#table-end').on('click', '.bt-inativa', function () {
        var obj = tableend.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/endereco/inativar',
            url: '/endereco/inativar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idend,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // ao digitar o CEP faz a pesquisa para facilitar pro usuário
    $('input[name=cep]').on('change', function () {
        $.getJSON("//viacep.com.br/ws/" + $(this).val() + "/json/?callback=?", function (dados) {
            if (!("erro" in dados)) {
                //Atualiza os campos com os valores da consulta.
                $("input[name=logradouro]").val(dados.logradouro);
                $("input[name=bairro]").val(dados.bairro);
                $("input[name=cidade]").val(dados.localidade);
                $("select[name=uf]").val(dados.uf);
            }
            else {
                console.log('CEP não encontrado ou WebService indisponível');
            }
        });
    });

    // botão de marcar endereço como preferencial
    $('#table-end').on('click', '.bt-pref', function () {
        var obj = tableend.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/endereco/preferencial',
            url: '/endereco/preferencial',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idend,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de marcar endereço como não preferencial
    $('#table-end').on('click', '.bt-npref', function () {
        var obj = tableend.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/endereco/naopreferencial',
            url: '/endereco/naopreferencial',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idend,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    //#endregion

    //#region Eventos Email

    // ao clicar no botão para adicionar novo email (abrir modal)
    $('#bt-addmail').on('click', function () {
        $('.cadform[name=mail]').show();
    });

    // ao clicar no botão de cadastrar novo email
    $('form[name=cadmail]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/email/inserir',
            url: '/email/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                $('.cadform[name=mail]').hide();
                $('form[name=cadmail]')[0].reset();
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });

    });

    // botão de reativar email
    $('#table-mail').on('click', '.bt-reativa', function () {
        var obj = tablemail.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/email/reativar',
            url: '/email/reativar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idmail,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de inativar email
    $('#table-mail').on('click', '.bt-inativa', function () {
        var obj = tablemail.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/email/inativar',
            url: '/email/inativar',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idmail,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de marcar email como preferencial
    $('#table-mail').on('click', '.bt-pref', function () {
        var obj = tablemail.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/email/preferencial',
            url: '/email/preferencial',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idmail,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    // botão de marcar email como não preferencial
    $('#table-mail').on('click', '.bt-npref', function () {
        var obj = tablemail.row($(this).parent().parent()).data();

        $.ajax({
            //url: 'http://localhost:9617/email/naopreferencial',
            url: '/email/naopreferencial',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: '=' + obj.idmail,
            success: function (r) {
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });
    });

    //#endregion

    //#region Eventos Tabulação

    // ao clicar no botão para adicionar nova tabulação (abrir modal)
    $('#bt-addtab').on('click', function () {
        $('.cadform[name=tab]').show();
    });

    // ao clicar no botão de cadastrar nova tabulação
    $('form[name=cadtab]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/tabulacao/inserir',
            url: '/tabulacao/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                $('.cadform[name=tab]').hide();
                $('form[name=cadtab]')[0].reset();
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });

    });

    // ao escolher um tabulação, popular data de agendamento
    $('form[name=cadtab] select[name=idocor]').on('change', function () {

        // recupera o idocor da tabulação escolhida
        var idocor = $(this).val();

        // acha a tabulação escolhida na listagem de ocorrencias
        var ocorrencia = findObjOnArray(idocor, 'idocor', ocorrencias);

        // popula o agendamento padrão desta ocorrencia
        var agendpadrao = new Date();
        agendpadrao.setMinutes(agendpadrao.getMinutes() + ocorrencia.agnd_padrao);
        $('form[name=cadtab] input[name=dtagend]').val(formatarDateTime(agendpadrao));

        // se for agendável reabilita o campo
        if (ocorrencia.agendavel)
            $('form[name=cadtab] input[name=dtagend]').prop('disabled', false);
        else
            $('form[name=cadtab] input[name=dtagend]').prop('disabled', true);


    });

    //#endregion

    //#region Eventos de Agendamento

    // ao clicar no botão para adicionar novo agendamento (abrir modal)
    $('#bt-addagendamento').on('click', function () {
        $('.cadform[name=agendamento]').show();
    });

    // ao clicar no botão de cadastrar novo agendamento
    $('form[name=cadagendamento]').on('submit', function (event) {
        event.preventDefault();

        $.ajax({
            //url: 'http://localhost:9617/agendamento/inserir',
            url: '/agendamento/inserir',
            type: 'POST',
            headers: { 'token': sessionStorage.getItem('token') },
            data: $(this).serialize(),
            success: function (r) {
                $('.cadform[name=agendamento]').hide();
                $('form[name=cadagendamento]')[0].reset();
                PopularFicha();
            },
            error: function (err) {
                if (err.status === 400)
                    alert(err.responseText);
                else
                    alert('Erro ao conectar com o servidor');
            }
        });

    });

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
                PopularFicha();
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
        // popula a ficha
        PopularFicha();
        // fecha o modal de edição
        $('.editform[name=agendamento]').hide();
        $('form[name=editagendamento]')[0].reset();
    });

    //#endregion

});