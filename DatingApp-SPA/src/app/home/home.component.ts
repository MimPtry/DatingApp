import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  // values: any;

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    // this.getValues();
  }
  // tslint:disable-next-line:typedef
  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  // tslint:disable-next-line:typedef
  // getValues() {
  //   this.http.get('http://localhost:5000/api/values').subscribe(response => {
  //     this.values = response;
  //   }, error => {
  //     console.log(error);
  //   });
  // }

  // tslint:disable-next-line:typedef
  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
