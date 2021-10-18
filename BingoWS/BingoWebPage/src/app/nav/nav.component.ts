import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private http: HttpClient) { }
  numero: any;

  ngOnInit(): void {
  }

  getNumero()
  {
    this.http.get('https://localhost:5001/api/Bingo/' + 'Rodada').subscribe(response =>{
      this.numero = response;
    }, error => {
      console.log(error)
    });
  }

}
