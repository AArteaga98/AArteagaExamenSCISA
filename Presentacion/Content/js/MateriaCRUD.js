$(document).ready(function () { //click
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5156/api/Materia/MostrarTodasLasMaterias',
        success: function (result) { //200 OK 
            $('#myModal').modal('hide');
            $('#portfolioModal1').modal('hide');

            $('#Seccion1').empty();
            $.each(result.objects, function (i, materia) {
                var filas =
                    + '<div class="d-flex flex-column flex-md-row justify-content-between mb-5">'
                    + ' <div class="flex-grow-1">'
                    + "<h3 class='mb-0'>" + materia.nombre + "</h3>"
                    + ' <div class="subheading mb-3"> Semestral </div>'
                    + "<p>" + materia.descripcion +"</p>"
                    + '</div>'   
                    + "<div class='flex-shrink-0'><span class='text-primary'> Costo: $ " + materia.costo + "</span></div>"

                    + '<a href="#" class="btn btn-warning bi bi-pencil-square" onclick="GetById(' + materia.idMateria + ')">'
                    + '<a href="#" class="btn btn-danger bi bi-trash" onclick="Eliminar(' + materia.idMateria + ')">'

                    + ' </div>' 

                $('#Seccion1').show();

                   
               
                //    '<tr>'
                //    + '<td class="text-center"> '
                //    + '<a href="#" class="btn btn-warning bi bi-pencil-square" onclick="GetById(' + materia.idMateria + ')">'
                //    + '</a> '
                //    + '</td>'
                //    + "<td class='text-center'>" + materia.nombre + "</td>"
                //    + "<td class='text-center'>" + materia.costo + "</ td>"
                //    + "<td class='text-center'>" + materia.descripcion + "</td>"        
                //    + '<td class="text-center"> '
                //    + '<a href="#" class="btn btn-danger bi bi-trash" onclick="Eliminar(' + materia.idMateria + ')">'
                //    + '</a> '
                //    + '</td>'


                //    + "</tr>";
                $("#Seccion1").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function Modal() {
    var mostrar = $('#portfolioModal1').modal('show');
    IniciarMateria();

}

function IniciarMateria() {

    var materia = {
        IdMateria: $('#txtIdMateria').val(''),
        Nombre: $('#txtNombre').val(''),
        Costo: $('#txtCosto').val(''),
        Descripcion: $('#txtDescripcion').val('')
        
     
    }
    $('#portfolioModal1').modal('show');
}


function GetById(idMateria) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5156/api/Materia/MostrarUnaMateria/' + idMateria,
        success: function (result) {
            $('#txtIdMateria').val(result.object.idMateria);
            $('#txtNombre').val(result.object.nombre);
            $('#txtCosto').val(result.object.costo);
            $('#txtDescripcion').val(result.object.descripcion);
            $('#portfolioModal1').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Actualizar() {
    var materia = {
        IdMateria: $('#txtIdMateria').val(),
        Nombre: $('#txtNombre').val(),
        Costo: $('#txtCosto').val(),
        Descripcion: $('#txtDescripcion').val()
    }
    if (materia.IdMateria == '') {
        Add(materia);

    }
    else {
        Update(materia);
    }
}


function Add(materia) {
    materia.IdMateria = 0;
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5156/api/Materia/AgregarMateria',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify(materia),
        success: function (result) {
            $('#myModal').modal();
            $('#portfolioModal1').modal('hide');
            $('#materia').modal('show');
            
            /*GetAll();*/
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Update(materia) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5156/api/Materia/ActualizarMateria',
        datatype: 'json',
        data: JSON.stringify(materia),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#portfolioModal1').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function Eliminar(idMateria) {
    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:5156/api/Materia/Delete/' + idMateria,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };
};


function ModalCerrar() {
    $('#portfolioModal1').modal('hide');
}



