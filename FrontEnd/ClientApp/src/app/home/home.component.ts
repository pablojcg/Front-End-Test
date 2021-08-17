import { Component, OnInit } from '@angular/core';
import { faCoffee, faAngleLeft, faAngleRight } from '@fortawesome/free-solid-svg-icons';
import Swal from 'sweetalert2';
import { ApiControllerService } from '../services/ApiController.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  faCoffee     = faCoffee;
  faAngleLeft  = faAngleLeft;
  faAngleRight = faAngleRight;

  constructor(private ApiControllerService: ApiControllerService, private router: Router) {}

  public onSearchIdentifiacion() {
    var nit = ((document.getElementById("nit") as HTMLInputElement).value);

    console.log("el nit es: " + nit);

    if (nit.length === 0) {
      Swal
        .fire({
          title: "Warning - NIT: " + nit,
          text: "Debe ingresar un NIT",
          icon: 'warning'
        });
    } else {
      this.ApiControllerService.searchIdentifiactionCompany(nit).subscribe((data: any) => {
        console.table(data);
        if (data.state == "602") {
          Swal
            .fire({
              title: "Error en la busqueda - NIT: " + nit,
              text: data.message,
              icon: 'error'
            });
        } else if (data.state == "601") {
          Swal
            .fire({
              title: "Warning - NIT: " + nit,
              text: data.message,
              icon: 'warning'
            });
        } else if (data.state == "200") {
          localStorage.setItem('nitCompany', nit);
          this.router.navigate(['fetch-data']);
        }
      }, error => {
        console.error(error);
      });
    }

    (document.getElementById("nit") as HTMLInputElement).value = "";
    
    //alert('Dio Click en Continuar y el valor del Nit es: ' + nit);
    //Swal.fire('Dio Click en Continuar y el valor del Nit es: ' + nit);
    /*
            Swal
          .fire({
            title: "Venta #123465",
            text: "¿Eliminar?",
            icon: 'error',
            showCancelButton: true,
            confirmButtonText: "Sí, eliminar",
            cancelButtonText: "Cancelar",
          })
          .then(resultado => {
            if (resultado.value) {
              // Hicieron click en "Sí"
              console.log("*se elimina la venta*");
            } else {
              // Dijeron que no
              console.log("*NO se elimina la venta*");
            }
          });
     */
  }

  ngOnInit() {

    this.ApiControllerService.GetAllType().subscribe((data: any) => {
      console.table(data);
    }, error => {
      console.error(error);
    });

  }

}
