"use strict"
$.fn.GCETable = function (options) {
    $(this).dataTable($.extend({
        language: {
            sEmptyTable: "Nenhum registro encontrado",
            sInfo: "Listando _START_-_END_ de _TOTAL_ registros.",
            sInfoEmpty: "nenhum dado",
            sInfoFiltered: "(Filtrados de _MAX_ registros)",
            sInfoPostFix: "",
            sInfoThousands: ".",
            sLengthMenu: "_MENU_ resultados por página",
            sLoadingRecords: "Carregando...",
            sProcessing: "Processando...",
            sZeroRecords: "Nenhum registro encontrado",
            sSearch: "Pesquisar",
            oPaginate: {
                sNext: "Próximo",
                sPrevious: "Anterior",
                sFirst: "Primeiro",
                sLast: "Último"
            },
            oAria: {
                sSortAscending: ": Ordenar colunas de forma ascendente",
                sSortDescending: ": Ordenar colunas de forma descendente"
            }
        },
        bLengthChange: false,
        processing: true,
        filter: false,
        lengthMenu: [10, 25, 50, 100, 150, 200],
        pageLength: 25,
        serverSide: true
    }, options));
    return this;
}