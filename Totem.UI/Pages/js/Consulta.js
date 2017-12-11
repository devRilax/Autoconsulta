var consulta = {

    init: function () {
        consulta.setupButtons();
    },
    setupButtons: function () {

        $("#btnEnviarEmail").hide();

        $("#btnEnviarEmailAjx").on("click", function () {

            if (consulta.fnValidateInput()) {
            
                var $this = $(this);
                $this.button('loading');
                setTimeout(function () {
                    $this.button('reset');
                }, 5500);

                consulta.fnEnviarEmail();
            }
         
        });
    },
    fnEnviarEmail: function () {

        var txtRun = $("#lblRun").html();

        var params = JSON.stringify({ run: txtRun, email: $("#txtEmailAjx").val() });
       
        $.ajax({

            type          : "POST",
            url           : "../Pages/PanelAlumno.aspx/enviarEmail",
            data          : params,
            contentType   : "application/json; charset=utf-8", 
            dataType      : "json", 
            success       : consulta.fnEmailSuccess,
            error         : function (request, status, error) {
                                console.log(status + " " + error + " " + request.responseText);
                            }
        });
    },
    fnEmailSuccess: function (data) {
        
        var respuesta = jQuery.parseJSON(data.d);

        if (respuesta.status === "OK") {
            msgRespuesta(respuesta.mensaje, 'success');
            $("#modalEmail").modal('hide');
            $("#txtEmailAjax").text('');
        }

        if (respuesta.status === "error") {
            $("#modalEmail").modal('hide');
            alert(respuesta.mensaje);
            $("#txtEmailAjx").text('');
        }
    },
    fnValidateInput: function () {
        var mail = $("#txtEmailAjx").val();
        var mailFormat = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
        var msj = "";
        var isValid = true;

        if (mail.length === 0) {
            isValid = false;
            msj = "Debe ingresar una dirección de correo";
        } else if(!(mailFormat.test(mail))) {
            isValid = false;
            msj = "La dirección de correo ingresada es inválida";
        }

        if (!isValid) {
            msgRespuesta(msj,'error');
        }

        return isValid;
    }

};
$(document).ready(consulta.init);