$(document).ready(function () {
    cargarTablaAutores();
    $("#btnCrearAutor").on("click", function (e) {
        e.preventDefault();
        var modalContent = `
            <div id="containerWrapper" style="position: relative;">
                <form id="autorForm">
                    <div class="form-group row row-custom">
                      <label name="Rut" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Rut:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="rut" placeholder="Ingrese rut del autor">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="Nombre" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Nombre:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="nombreAutor" placeholder="Ingrese el nombre del autor">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="FechaNacimiento" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Fecha Nacimiento:</label>
                        <div class="col-sm-10">
                            <input type="date" class="form-control" id="fechaNacimiento">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="Nombre" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Ciudad:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="ciudadAutor" placeholder="Ingrese ciudad del autor">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="Nombre" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Correo:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="correoAutor" placeholder="Ingrese correo del autor">
                        </div>
                    </div>
                    <div class="form-group row row-custom" id="errorMensaje" style="color: red; display: none;">
                        <label class="col-sm-2 col-form-label"></label>
                        <div class="col-sm-10">
                            Por favor, complete todos los campos requeridos.
                        </div>
                    </div>
                    <button type="button" class="btn btn-primary" id="btnGrabarAutor">Grabar</button>
                    <button type="button" class="btn btn-secondary" id="btnCancelar">Cancelar</button>
                </form>
            </div>`;
        Swal.fire({
            html: modalContent,
            title: "Agregar Autor",
            confirmButtonText: "Cerrar",
            showConfirmButton: false,
            width: '50%',
            allowOutsideClick: false,
            clickOutside: false,
            onOpen: function () {

                $("#btnGrabarAutor").on("click", function (e) {
                    debugger;
                    e.preventDefault();
                    var autorModel = {
                        Rut: $("#rut").val(),
                        NombreCompleto: $("#nombreAutor").val(),
                        FechaNacimiento: $("#fechaNacimiento").val(),
                        CiudadProcedencia: $("#ciudadAutor").val(),
                        CorreoElectronico: $("#correoAutor").val()
                    };
                    $.ajax({
                        url: '/Autor/CrearAutor',
                        type: 'POST',
                        data: autorModel,
                        success: function (data) {
                            if (data.success) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Autor',
                                    confirmButtonText: "Cerrar",
                                    text: data.mensaje,
                                    allowOutsideClick: false,
                                    clickOutside: false
                                }).then((result) => {
                                    debugger;
                                    if (result.isConfirmed) {
                                        cargarTablaAutores();
                                    }
                                });
                            } else {
                                Swal.fire({
                                    icon: "error",
                                    customClass: {
                                        title: 'popup-title',
                                        text: 'swal2-html-container-message',
                                        confirmButtonColor: 'swal2-styled swal2-confirm'
                                    },
                                    text: data.mensaje,
                                    confirmButtonText: "Cerrar",
                                    allowOutsideClick: false,
                                    clickOutside: false
                                });
                            }
                        },
                        error: function (xhr, status, error) {
                            alert('Error al crear el autor: ' + xhr.responseText);
                        }
                    });
                });
                $("#btnCancelar").on('click', function () {
                    Swal.close();
                });
            }
        });
    });

    $("#tablaAutores").on("click", "#btnAgregarLibro", function () {
        var rutAutor = $(this).data('rut');
        var modalContent = `
            <div id="containerWrapper" style="position: relative;">
                <form id="libroForm">
                    <div class="form-group row row-custom">
                      <label name="Titulo" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Titulo:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="titulo" placeholder="Ingrese titulo del libro">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="Año" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Año:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="año" placeholder="Ingrese año del libro">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="Genero" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">Genero:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="genero" placeholder="Ingrese genero del libro">
                        </div>
                    </div>
                    <div class="form-group row row-custom">
                        <label name="NumeroPaginas" style="display: flex; justify-content: start; text-align:left;" class="col-sm-2 col-form-label">N° Paginas:</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="numeroPaginas" placeholder="Ingrese número de paginas">
                        </div>
                    </div>
                    <div class="form-group row row-custom" id="errorMensaje" style="color: red; display: none;">
                        <label class="col-sm-2 col-form-label"></label>
                        <div class="col-sm-10">
                            Por favor, complete todos los campos requeridos.
                        </div>
                    </div>
                    <button type="button" class="btn btn-primary" id="btnGrabarLibro">Grabar</button>
                    <button type="button" class="btn btn-secondary" id="btnCancelar">Cancelar</button>
                </form>
            </div>`;
        Swal.fire({
            html: modalContent,
            title: "Agregar Libro",
            confirmButtonText: "Cerrar",
            showConfirmButton: false,
            width: '50%',
            allowOutsideClick: false,
            clickOutside: false,
            onOpen: function () {

                $("#btnGrabarLibro").on("click", function (e) {
                    debugger;
                    e.preventDefault();
                    var libroModel = {
                        Titulo: $("#titulo").val(),
                        Año: $("#año").val(),
                        Genero: $("#genero").val(),
                        NumeroPaginas: $("#numeroPaginas").val(),
                        AutorRut: rutAutor
                    };
                    $.ajax({
                        url: '/Libro/CrearLibro',
                        type: 'POST',
                        data: libroModel,
                        success: function (data) {
                            if (data.success) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Libro',
                                    confirmButtonText: "Cerrar",
                                    text: data.mensaje,
                                    allowOutsideClick: false,
                                    clickOutside: false
                                });
                            } else {
                                Swal.fire({
                                    icon: "error",
                                    customClass: {
                                        title: 'popup-title',
                                        text: 'swal2-html-container-message',
                                        confirmButtonColor: 'swal2-styled swal2-confirm'
                                    },
                                    text: data.mensaje,
                                    confirmButtonText: "Cerrar",
                                    allowOutsideClick: false,
                                    clickOutside: false
                                });
                            }
                        },
                        error: function (xhr, status, error) {
                            alert('Error al crear el autor: ' + xhr.responseText);
                        }
                    });
                });
                $("#btnCancelar").on('click', function () {
                    Swal.close();
                });
            }
        });
    });

    $("#tablaAutores").on("click", "#btnVerLibros", function () {
        debugger;
        var rutAutor = $(this).data('rut');
        $.ajax({
            url: '/Libro/ObtenerLibrosPorAutor',
            type: 'GET',
            data: { rut: rutAutor },
            success: function (data) {
                if (data.success) {
                    Swal.fire({
                        html: data.data,
                        title: "Lista libros",
                        confirmButtonText: "Cerrar",
                        showConfirmButton: true,
                        width: '50%',
                        allowOutsideClick: false,
                        clickOutside: false
                    });
                } else {
                    Swal.fire({
                        icon: "error",
                        customClass: {
                            title: 'popup-title',
                            text: 'swal2-html-container-message',
                            confirmButtonColor: 'swal2-styled swal2-confirm'
                        },
                        text: data.mensaje,
                        confirmButtonText: "Cerrar",
                        allowOutsideClick: false,
                        clickOutside: false
                    });
                }
            },
            error: function (xhr, status, error) {
                alert('Error al obtener la lista de libros: ' + xhr.responseText);
            }
        });
    });
});
function cargarTablaAutores() {
    debugger;
    if (!$.fn.DataTable.isDataTable('#tablaAutores')) {
        $('#tablaAutores').DataTable({
            lengthChange: false,
            language: {
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "No existen autores.",
                "sInfo": "Mostrando autores de un total de _TOTAL_",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ compañias)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                },
                buttons: {
                    pageLength: 'Mostrar %d registros <i class="fa fa-caret-down" aria-hidden="true"></i>'
                }
            }
        });
    }

    $.ajax({
        url: '/Autor/ObtenerAutores',
        type: 'GET',
        success: function (data) {
            if (data.success) {
                // Obtener la instancia del DataTable
                var table = $('#tablaAutores').DataTable();

                // Limpiar el cuerpo de la tabla
                table.clear();

                // Recorrer los datos y agregarlos al DataTable
                data.data.forEach(function (autor) {
                    var fechaNacimiento = new Date(autor.fechaNacimiento).toISOString().split('T')[0];
                    var row = `
                        <tr>
                            <td>${autor.rut}</td>
                            <td>${autor.nombreCompleto}</td>
                            <td>${fechaNacimiento}</td>
                            <td>${autor.ciudadProcedencia}</td>
                            <td>${autor.correoElectronico}</td>
                            <td>
                                <button class='btn btn-primary' data-rut=${autor.rut} data-toggle='tooltip' data-placement='top' title='Ver Libros' id='btnVerLibros'><i class='bx bx-info-square'></i></button>
                                <button class='btn btn-success' data-rut=${autor.rut} data-toggle='tooltip' data-placement='top' title='Agregar Libro' id='btnAgregarLibro'><i class='bx bx-add-to-queue'></i></button>
                            </td>
                        </tr>`;

                    table.row.add($(row));
                });

                // Redibujar el DataTable después de agregar los datos
                table.draw();
            } else {
                alert('Error al obtener la lista de autores: ' + data.mensaje);
            }
        },
        error: function (xhr, status, error) {
            alert('Error al obtener la lista de autores: ' + xhr.responseText);
        }
    });
}


