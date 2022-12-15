$(document).ready(function () {
    var codigoColegiatura;

    $('#ColegiaturasTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitoso").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCampos();
        location.reload();
    });

    $("#btnAgregarColegiatura").click(function () {
        if (validarCamposColegiatura()) {

            var codigoColegiatura = document.getElementById("IDAgregarColegiaturaCodigo").value;

            if (codigoColegiatura == "") {

                $.ajax({
                    url: '/Colegiatura/AgregarColegiatura',
                    type: 'POST',
                    data: {
                        nombre: document.getElementById("IDAgregarColegiaturaNombre").value,
                        facultad: document.getElementById("IDAgregarColegiaturaFacultad").value,
                        gradoAcademico: document.getElementById("IDAgregarColegiaturaGradoAcademico").value,
                        acreditada: document.getElementById("IDAgregarColegiaturaAcreditada").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarColegiaturaAcreditada");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Colegiatura/EditarColegiatura',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarColegiaturaCodigo").value,
                        nombre: document.getElementById("IDAgregarColegiaturaNombre").value,
                        facultad: document.getElementById("IDAgregarColegiaturaFacultad").value,
                        gradoAcademico: document.getElementById("IDAgregarColegiaturaGradoAcademico").value,
                        acreditada: estadoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarColegiatura").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarColegiatura']").click(function () {

        codigoColegiatura = $(this).data("id");
        var verDetalle = VerDetalleColegiatura(codigoColegiatura);

    });

    $("a[name='btnEliminarColegiatura']").click(function () {

        codigoColegiatura = $(this).data("id");
        $('#modalVentanaEliminarColegiatura').modal('show');
    });

    $("#btnAbrirDialogAgregarColegiatura").click(function () {
        $('#modalAgregarColegiatura').modal('show');
    });

    $("#btnAceptarEliminarColegiaturaConfirmacion").click(function () {

        $.ajax({
            url: '/Colegiatura/EliminarColegiatura',
            type: 'POST',
            data: {
                Codigo: codigoColegiatura
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarColegiatura').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarColegiaturaConfirmacion").click(function () {
        $('#modalVentanaEliminarColegiatura').modal('hide');
        location.reload();
    });

    $("#textoBuscarColegiatura").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ColegiaturasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarColegiatura').modal('hide');

    document.getElementById("IDAgregarColegiaturaCodigo").value = "";
    document.getElementById("IDAgregarColegiaturaNombre").value = "";
    document.getElementById("IDAgregarColegiaturaFacultad").value = "";
    document.getElementById("IDAgregarColegiaturaGradoAcademico").value = "";
    document.getElementById("IDAgregarColegiaturaAcreditada").value = "";


    $("IDAgregarColegiaturaCodigo").css('border', '1px solid #ced4da');
    $("IDAgregarColegiaturaNombre").css('border', '1px solid #ced4da');
    $("IDAgregarColegiaturaFacultad").css('border', '1px solid #ced4da');
    $("IDAgregarColegiaturaGradoAcademico").css('border', '1px solid #ced4da');
    $("IDAgregarColegiaturaAcreditada").css('border', '1px solid #ced4da');

}



function validarCamposColegiatura() {
    var bandera = true;
    var agregarColegiaturaNombre = document.getElementById("IDAgregarColegiaturaNombre").value;
    var agregarColegiaturaFacultad = document.getElementById("IDAgregarColegiaturaFacultad").value;
    var agregarColegiaturaGradoAcademico = document.getElementById("IDAgregarColegiaturaGradoAcademico").value;
    var agregarColegiaturaAcreditada = document.getElementById("IDAgregarColegiaturaAcreditada").value;

    if (agregarColegiaturaNombre == "") {
        $("#IDAgregarColegiaturaNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarColegiaturaNombre').css('border', '1px solid #ced4da');
    }

    if (agregarColegiaturaFacultad == "") {
        $("#IDAgregarColegiaturaFacultad").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarColegiaturaFacultad').css('border', '1px solid #ced4da');
    }

    if (agregarColegiaturaGradoAcademico == "") {
        $("#IDAgregarColegiaturaGradoAcademico").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarColegiaturaGradoAcademico').css('border', '1px solid #ced4da');
    }

    if (agregarColegiaturaAcreditada == "") {
        $("#IDAgregarColegiaturaAcreditada").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarColegiaturaAcreditada').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleColegiatura(codigo) {

    $.ajax({
        url: '/Colegiatura/VerDetalleColegiatura',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarColegiaturaCodigo").value = response.codigo;
            document.getElementById("IDAgregarColegiaturaNombre").value = response.nombre;
            document.getElementById("IDAgregarColegiaturaFacultad").value = response.facultad;
            document.getElementById("IDAgregarColegiaturaGradoAcademico").value = response.gradoAcademico;
            document.getElementById("IDAgregarColegiaturaAcreditada").value = response.acreditada;

            $('#modalAgregarColegiatura').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
