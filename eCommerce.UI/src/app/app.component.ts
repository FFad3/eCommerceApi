import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public categories?: Category[];

  constructor(http: HttpClient) {
    http.get<Category[]>('/api/Category').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }

  title = 'eCommerce.UI';
}

interface Category {
  id: string;
  name: string;
  productsCount: number;
}
