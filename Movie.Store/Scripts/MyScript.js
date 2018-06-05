
$(function () {

    var createAutocomplete = function () {
        var $input = $(this);

        $input.autocomplete({
            source: $input.attr("data-ms-autocomplete")
        });
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            type: "get"
        };
        
        $.ajax(options).done(function (data) {
            var target = $a.parents("div.movieList").attr("data-ms-target");
            $(target).replaceWith(data);
        });
        
    };

    $("input[data-ms-autocomplete]").each(createAutocomplete);

    $(".pagedList a").click(getPage);
});