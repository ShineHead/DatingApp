import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  values: any;


  // Performs HTTP requests. This service is available as an injectable class, with methods to perform HTTP requests.
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }

  //Constructs a GET request that interprets the body as a JSON object and returns the response body as a JSON object.
  //@return — An Observable of the response body as a JSON object. -- OBSERVABLE is a stream of data getting from our API
  getValues() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }


}