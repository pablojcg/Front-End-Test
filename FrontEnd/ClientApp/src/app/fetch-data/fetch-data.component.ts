import { Component, OnInit } from '@angular/core';
import { faCoffee, faAngleLeft, faAngleRight } from '@fortawesome/free-solid-svg-icons';
import { ApiControllerService } from '../services/ApiController.service';
import { ICompany } from '../models/ICompany';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  faCoffee = faCoffee;
  faAngleLeft = faAngleLeft;
  faAngleRight = faAngleRight;
  typeIdentification: any;
  dataCompany: any;
  typeHidden: any;
  updateCompany: ICompany;


  constructor(private ApiControllerService: ApiControllerService,) { }

  ngOnInit() {

    let nitCompany = localStorage.getItem('nitCompany');

    console.log(nitCompany);

    this.ApiControllerService.GetAllType().subscribe((data: any) => {

      if (data != null) {
        this.typeIdentification = data;
        console.table(this.typeIdentification);
      }
    }, error => {
      console.error(error);
    });

    this.ApiControllerService.searchIdentifiactionCompany(nitCompany).subscribe((data: any) => {

      if (data.state == "200") {
        this.dataCompany = data.custom;
        if (this.dataCompany.idIdentificationType === 1 || this.dataCompany.idIdentificationType === 3) {
          this.typeHidden = true;
        } else {
          this.typeHidden = false;
        }
        console.table(this.dataCompany);
      }
    }, error => {
      console.error(error);
    });

  }

  public onSaveInfo() {

    var checkboxEmail = (document.getElementById('customCheckbox1') as HTMLInputElement);
    var checkboxPhone = (document.getElementById('customCheckbox2') as HTMLInputElement);
    var identificationNumber = parseInt((document.getElementById('idNumber') as HTMLInputElement).value);
    var companyName = (document.getElementById('companyName') as HTMLInputElement).value;
    var firtsName = (document.getElementById('firtsName') as HTMLInputElement).value;
    var secondName = (document.getElementById('secondName') as HTMLInputElement).value;
    var firtsLastName = (document.getElementById('firtsLastName') as HTMLInputElement).value;
    var secondLastName = (document.getElementById('secondLastName') as HTMLInputElement).value;
    var email = (document.getElementById('email') as HTMLInputElement).value;
    var phone = (document.getElementById('phone') as HTMLInputElement).value;
    var idIdentificationType = parseInt((document.getElementById('TypeID') as HTMLInputElement).value);

    this.updateCompany = {
      idCompany: this.dataCompany.idCompany,
      identificationNumber: identificationNumber,
      nitCompany: this.dataCompany.nitCompany,
      companyName: companyName,
      firtsName: firtsName,
      secondName: secondName,
      firtsLastName: firtsLastName,
      secondLastName: secondLastName,
      email: email,
      phone: phone,
      authorizedSendEmail: checkboxEmail.checked,
      authorizedSendPhone: checkboxPhone.checked,
      idIdentificationType: idIdentificationType
    };
    this.ApiControllerService.updateCompany(this.updateCompany).subscribe((data: any) => {
      console.log(data);
      if (data.state == "601") {
        Swal
          .fire({
            title: "Error ",
            text: data.message,
            icon: 'error'
          });
      } else if (data.state == "200") {
        Swal
          .fire({
            title: "Success",
            text: data.message,
            icon: 'success'
          });
      }
    }, error => {
      console.error(error);
    });
    
  }
}

