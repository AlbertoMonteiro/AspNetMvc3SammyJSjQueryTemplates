/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="sammy-latest.min.js" />
/// <reference path="sammy.title.min.js" />
/// <reference path="jquery.tmpl.min.js" />

var app = Sammy('#main', function () {
    this.use(Sammy.Title).use('jQuery.template');

    //Controller Home

    this.get("#/about", function (context) {
        context.title('Testando Sammy - About');
        $.getJSON('/Home/About', function (json) {
            context.partial('Assets/templates/about.htm', json);
        });
    });

    this.get("#/", function (context) {
        context.title('Testando Sammy');
        $.getJSON('/Home/Start', function (json) {
            $.get('Assets/templates/index.htm', function (html) {
                context.$element().html($(html).tmpl(json));
            });
        });
    });

    //Controller Person

    this.get("#/persons", function (context) {
        context.title('Testando Sammy - Lista de pessoas');
        $.getJSON('/Pessoa/Index', function (json) {
            $.get('Assets/templates/person/index.htm', function (html) {
                context.$element().html($(html).tmpl(json));
            });
        });
    });

    this.get("#/persons/add", function (context) {
        context.title('Testando Sammy - Nova pessoa');
        $.get('Assets/templates/person/novo.htm', function (html) {
            context.$element().html(html);
        });
    });

    this.post("#/persons/add", function (context) {
        var fields = {
            nome: context.params['nome'],
            nascimento: context.params['nascimento'],
            sexo: context.params['sexo']
        };

        $.post('/Pessoa/Novo', fields, function (response) {
            context.redirect('#/persons');
        });
    });

    this.get("#/persons/edit/:id", function (context) {
        context.title('Testando Sammy - Editar pessoa');
        $.getJSON('/Pessoa/Index', function (json) {
            $.get('Assets/templates/person/novo.htm', function (html) {
                context.$element().html($(html).tmpl(json));
            });
        });
    });
});