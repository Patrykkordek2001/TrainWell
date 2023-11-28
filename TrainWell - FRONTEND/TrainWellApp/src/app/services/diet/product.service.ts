import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto } from 'src/app/Models/diet/ProductDto';
import { ProductPreview } from 'src/app/Models/diet/ProductPreview';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  getAllMeals(): Observable<ProductPreview[]> {
    return this.httpClient.get<ProductPreview[]>('https://localhost:7004/api/Product/GetAllProducts');
  }
  addProduct(productData: ProductDto): Observable<any> {
    return this.httpClient.post<number>('https://localhost:7004/api/Product/AddProduct',productData);
  }
}
