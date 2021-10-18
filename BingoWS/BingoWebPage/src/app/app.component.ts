import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Bingo';
  cartelas: any;


  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCartela();
  }

  getCartela() {
    this.http.get('https://localhost:5001/api/Bingo/' + 'Card').subscribe(response =>{
      this.cartelas = response;
    }, error => {
      console.log(error)
    });
  }
}
