$(document).ready(function () {
    var codigoHorario;

    $('#HorariosTabla').DataTable({
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

    $("#btnAgregarHorario").click(function () {
        if (validarCamposHorario()) {

            var codigoHorario = document.getElementById("IDAgregarHorarioCodigo").value;

            if (codigoHorario == "") {

                $.ajax({
                    url: '/Horario/AgregarHorario',
                    type: 'POST',
                    data: {
                        horaInicio: document.getElementById("IDAgregarHorarioInicio").value,
                        horaFin: document.getElementById("IDAgregarHorarioFin").value,
                        dia: document.getElementById("IDAgregarHorarioDia").value,
                        sede: document.getElementById("IDAgregarHorarioSede").value,
                        aula: document.getElementById("IDAgregarHorarioAula").value

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
                var e = document.getElementById("IDAgregarHorarioSede");
                var sedeSelect = e.value;
                $.ajax({
                    url: '/Horario/EditarHorario',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarHorarioCodigo").value,
                        horaInicio: document.getElementById("IDAgregarHorarioInicio").value,
                        horaFin: document.getElementById("IDAgregarHorarioFin").value,
                        dia: document.getElementById("IDAgregarHorarioDia").value,
                        aula: document.getElementById("IDAgregarHorarioAula").value,
                        sede: document.getElementById("IDAgregarHorarioSede").value,
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

    $("#btnCancelarHorario").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarHorario']").click(function () {

        codigoHorario = $(this).data("id");
        var verDetalle = VerDetalleHorario(codigoHorario);

    });

    $("a[name='btnEliminarHorario']").click(function () {

        codigoHorario = $(this).data("id");
        $('#modalVentanaEliminarHorario').modal('show');
    });

    $("#btnAbrirDialogAgregarHorario").click(function () {
        $('#modalAgregarHorario').modal('show');
    });

    $("#btnAceptarEliminarHorarioConfirmacion").click(function () {

        $.ajax({
            url: '/Horario/EliminarHorario',
            type: 'POST',
            data: {
                Codigo: codigoHorario
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarHorario').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarHorarioConfirmacion").click(function () {
        $('#modalVentanaEliminarHorario').modal('hide');
        location.reload();
    });

    $("#textoBuscarHorario").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#HorariosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarHorario').modal('hide');

    document.getElementById("IDAgregarHorarioCodigo").value = "";
    document.getElementById("IDAgregarHorarioInicio").value = "";
    document.getElementById("IDAgregarHorarioFin").value = "";
    document.getElementById("IDAgregarHorarioDia").value = "";
    document.getElementById("IDAgregarHorarioSede").value = "";
    document.getElementById("IDAgregarHorarioAula").value = "";

    $("IDAgregarHorarioInicio").css('border', '1px solid #ced4da');
    $("IDAgregarHorarioFin").css('border', '1px solid #ced4da');
    $("IDAgregarHorarioDia").css('border', '1px solid #ced4da');
    $("IDAgregarHorarioSede").css('border', '1px solid #ced4da');
    $("IDAgregarHorarioAula").css('border', '1px solid #ced4da');
}



function validarCamposHorario() {
    var bandera = true;
    var agregarHorariohoraInicio = document.getElementById("IDAgregarHorarioInicio").value;
    var agregarHorariohoraFin = document.getElementById("IDAgregarHorarioFin").value;
    var agregarHorarioDia = document.getElementById("IDAgregarHorarioDia").value;
    var agregarHorariosede = document.getElementById("IDAgregarHorarioSede").value;
    var agregarHorarioAula = document.getElementById("IDAgregarHorarioAula").value;

    if (agregarHorariohoraInicio == "") {
        $("#IDAgregarHorarioInicio").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarHorarioInicio').css('border', '1px solid #ced4da');
    }

    if (agregarHorariohoraFin == "") {
        $("#IDAgregarHorarioFin").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarHorarioFin').css('border', '1px solid #ced4da');
    }

    if (agregarHorarioDia == "") {
        $("#IDAgregarHorarioDia").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarHorarioDia').css('border', '1px solid #ced4da');
    }

    if (agregarHorariohoraInicio == "") {
        $("#IDAgregarHorarioInicio").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarHorarioInicio').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleHorario(codigo) {

    $.ajax({
        url: '/Horario/VerDetalleHorario',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarHorarioSede").value = response.sede;
            document.getElementById("IDAgregarHorarioAula").value = response.aula;
            document.getElementById("IDAgregarHorarioFin").value = response.horaFin;
            document.getElementById("IDAgregarHorarioDia").value = response.dia;
            document.getElementById("IDAgregarHorarioInicio").value = response.horaInicio;
            document.getElementById("IDAgregarHorarioCodigo").value = response.codigo;
            $('#modalAgregarHorario').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
