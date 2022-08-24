
    var common = {
        init: function () {

    },
   register: function () {
       $("#textkey").autocomplete({
           minLength: 0,
           source: function (request, response) {
               $.ajax({
                   url: "/Product/ListName",
                   dataType: "jsonp",
                   data: {
                       q: request.term
                   },
                   success: function (response) {
                       response(response.data);
                   }
               });
           },
           focus: function (event, ui) {
               $("#textkey").val(ui.item.label);
               return false;
           },
           select: function (event, ui) {
               $("#textkey").val(ui.item.label);
               return false;
           }
       })
           .autocomplete("instance")._renderItem = function (ul, item) {
               return $("<li>")
                   .append("<a>" + item.label + "</a>")
                   .appendTo(ul);
           };
    }
}
    common.init();
      