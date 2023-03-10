import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title: string = 'Blog Engine';
  testString: any;
  
  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get('https://localhost:7055/api/blogs').subscribe({
      next: response => this.testString = response,
      error: () => console.log('error'),
      complete: () => console.log('request completed') 
    })
  }
}
