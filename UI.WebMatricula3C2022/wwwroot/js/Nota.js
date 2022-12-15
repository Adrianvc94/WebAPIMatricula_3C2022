$(document).ready(function () {
    var codigoNota;

    $('#NotasTabla').DataTable({
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

    $("#btnAgregarNota").click(function () {
        if (validarCamposNota()) {

            var codigoNota = document.getElementById("IDAgregarNotaCodigo").value;

            if (codigoNota == "") {

                $.ajax({
                    url: '/Nota/AgregarNota',
                    type: 'POST',
                    data: {
                        codigoCurso: document.getElementById("IDAgregarNotaCodigoCurso").value,
                        codigoEstudiante: document.getElementById("IDAgregarNotaCodigoEstudiante").value,
                        codigoProfesor: document.getElementById("IDAgregarNotaCodigoProfesor").value,
                        nota: document.getElementById("IDAgregarNota").value,
                        estado: document.getElementById("IDAgregarNotaEstado").value

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
                var e = document.getElementById("IDAgregarNotaEstado");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Nota/EditarNota',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarNotaCodigo").value,
                        codigoCurso: document.getElementById("IDAgregarNotaCodigoCurso").value,
                        codigoEstudiante: document.getElementById("IDAgregarNotaCodigoEstudiante").value,
                        codigoProfesor: document.getElementById("IDAgregarNotaCodigoProfesor").value,
                        nota: document.getElementById("IDAgregarNota").value,
                        estado: estadoSelect
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

    $("#btnCancelarNota").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarNota']").click(function () {

        codigoNota = $(this).data("id");
        var verDetalle = VerDetalleNota(codigoNota);

    });

    $("a[name='btnEliminarNota']").click(function () {

        codigoNota = $(this).data("id");
        $('#modalVentanaEliminarNota').modal('show');
    });

    $("#btnAbrirDialogAgregarNota").click(function () {
        $('#modalAgregarNota').modal('show');
    });

    $("#btnAceptarEliminarNotaConfirmacion").click(function () {

        $.ajax({
            url: '/Nota/EliminarNota',
            type: 'POST',
            data: {
                Codigo: codigoNota
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarNota').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarNotaConfirmacion").click(function () {
        $('#modalVentanaEliminarNota').modal('hide');
        location.reload();
    });

    $("#textoBuscarNota").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#NotasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarNota').modal('hide');

    document.getElementById("IDAgregarNotaCodigo").value = "";
    document.getElementById("IDAgregarNotaCodigoCurso").value = "";
    document.getElementById("IDAgregarNotaCodigoEstudiante").value = "";
    document.getElementById("IDAgregarNotaCodigoProfesor").value = "";
    document.getElementById("IDAgregarNota").value = "";
    document.getElementById("IDAgregarNotaEstado").value = "";


    $("IDAgregarNotaCodigoCurso").css('border', '1px solid #ced4da');
    $("IDAgregarNotaCodigoEstudiante").css('border', '1px solid #ced4da');
    $("IDAgregarNotaCorreo").css('border', '1px solid #ced4da');
    $("IDAgregarNotaCodigoProfesor").css('border', '1px solid #ced4da');
    $("IDAgregarNota").css('border', '1px solid #ced4da');
    $("IDAgregarNotaEstado").css('border', '1px solid #ced4da');

}



function validarCamposNota() {
    var bandera = true;
    var agregarNotaCodigoCurso = document.getElementById("IDAgregarNotaCodigoCurso").value;
    var agregarNotaCodigoEstudiante = document.getElementById("IDAgregarNotaCodigoEstudiante").value;
    var agregarNotaCodigoProfesor = document.getElementById("IDAgregarNotaCodigoProfesor").value;
    var agregarNota = document.getElementById("IDAgregarNota").value;
    var agregarNotaEstado = document.getElementById("IDAgregarNotaEstado").value;


    if (agregarNotaCodigoCurso == "") {
        $("#IDAgregarNotaCodigoCurso").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarNotaCodigoCurso').css('border', '1px solid #ced4da');
    }

    if (agregarNotaCodigoEstudiante == "") {
        $("#IDAgregarNotaCodigoEstudiante").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarNotaCodigoEstudiante').css('border', '1px solid #ced4da');
    }

    if (agregarNotaCodigoProfesor == "") {
        $("#IDAgregarNotaCodigoProfesor").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarNotaCodigoProfesor').css('border', '1px solid #ced4da');
    }

    if (agregarNota == "") {
        $("#IDAgregarNota").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarNota').css('border', '1px solid #ced4da');
    }

    if (agregarNotaEstado == "") {
        $("#IDAgregarNotaEstado").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarNotaEstado').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleNota(codigo) {

    $.ajax({
        url: '/Nota/VerDetalleNota',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarNotaCodigo").value = response.codigo;
            document.getElementById("IDAgregarNotaCodigoCurso").value = response.codigoCurso;
            document.getElementById("IDAgregarNotaCodigoEstudiante").value = response.codigoEstudiante;
            document.getElementById("IDAgregarNotaCodigoProfesor").value = response.codigoProfesor;
            document.getElementById("IDAgregarNota").value = response.nota;
            document.getElementById("IDAgregarNotaEstado").value = response.estado;
            $('#modalAgregarNota').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
