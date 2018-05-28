
$(function () {
    var createAutocomplete = function () {
        var $input = $(this);

        $input.autocomplete({
            source: $input.attr("data-ms-autocomplete")
        });
    };

    $("input[data-ms-autocomplete]").each(createAutocomplete);
});