import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { MealEnum } from 'src/app/Models/diet/MealEnum';
import { ProductPreview } from 'src/app/Models/diet/ProductPreview';
import { DateSharingService } from 'src/app/services/date-sharing.service';
import { MealService } from 'src/app/services/diet/meal.service';
import { ProductService } from 'src/app/services/diet/product.service';

@Component({
  selector: 'app-meals',
  templateUrl: './meals.component.html',
  styleUrls: ['./meals.component.css'],
})
export class MealsComponent implements OnInit, AfterViewInit {
  @ViewChild(MatTable) table!: MatTable<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  products: ProductPreview[] = [];

  mealFat:number = 0;
  mealProteins:number = 0;
  mealCarbohydrates:number = 0;
  mealCalories:number = 0;

  displayedColumns: string[] = [
    'Lp',
    'Nazwa',
    'Białko',
    'Tłuszcze',
    'Węglowodany',
    'Kalorie',
  ];
  meals: MealEnum[] = [
    MealEnum.Default,
    MealEnum.Breakfast,
    MealEnum.SecondBreakfast,
    MealEnum.Lunch,
    MealEnum.Snack,
    MealEnum.Dinner,
  ];
  dataSource = new MatTableDataSource<ProductPreview>(this.products);
  addMode: boolean = false;
  addProductForm!: FormGroup;
  addMealForm!: FormGroup;
  addProductMode:boolean = false;

  constructor(
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private dateSharingService: DateSharingService,
    private mealService: MealService
  ) {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit(): void {
    this.addMealForm = this.formBuilder.group({
      date: [new Date(), Validators.required],
      mealName: [null, Validators.required],
      productsInMeal: this.formBuilder.array([
        this.formBuilder.group({
          grams: ['', Validators.required],
          productId: ['', Validators.required],
        }),
      ]),
    });

    this.productService.getAllMeals().subscribe((response) => {
      this.products = response.map((product, index) => ({
        ...product,
        position: index + 1,
      }));
      this.dataSource.data = this.products;
      console.log(this.products);
    });

    this.setDateFromService();
  }

  get productsInMeal() {
    return (this.addMealForm.get('productsInMeal') as FormArray);
  }
  get date() {
    return this.addMealForm.get('date')?.value;
  }

  removeProductInMeal(index: number): void {
    this.productsInMeal.removeAt(index);
  }

  addProductInMeal(): void {
    this.productsInMeal.push(
      this.formBuilder.group({
        grams: [null, Validators.required],
        productId: [null, Validators.required],
      })
    );
    console.log(this.productsInMeal);
  }
  changeAddProductMode(){
    this.addProductMode = true;
  }
  cancelAddProductMode(){
    this.addProductMode = false;
  }

  private setDateFromService() {
    const selectedDate = this.dateSharingService.getSelectedDate();

    this.date?.setDate(selectedDate.getDate());
  }
  // removeProductInMeal(index: number): void {
  //   this.productsInMeal.removeAt(index);
  // }



  submitForm(): void {
    if (this.addMealForm.valid) {
      const formData = this.addMealForm.value;
      // Wywołaj API, aby przesłać dane do backendu
      this.mealService.addMeal(formData).subscribe(
        // Obsłuż odpowiedź z backendu
        (response) => {
          console.log('Posiłek dodany pomyślnie', response);
          // Możesz dodać dodatkowe akcje po dodaniu posiłku
        },
        // Obsłuż błędy z backendu
        (error) => {
          console.error('Błąd podczas dodawania posiłku', error);
        }
      );
    }
  }

  changeMode() {
    this.addMode = true;

    this.addProductForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      fat: ['', [Validators.required]],
      proteins: ['', [Validators.required]],
      carbohydrates: ['', [Validators.required]],
      calories: ['', [Validators.required]],
    });
  }
  cancel() {
    this.addMode = false;
  }


  

  addProduct() {
    console.log(this.addProductForm.value);
    if (this.addProductForm.valid) {
      const productData = this.addProductForm.value;
      this.productService.addProduct(productData).subscribe({
        next: (response) => {
          console.log(response);
          const newProduct = {
            ...response,
            position: this.products.length + 1,
          };
          this.products.push(newProduct);
          this.addProductForm.reset();
          this.table.renderRows();
        },
        error: (error) => {
          this.toastrService.error('Wystąpił błąd podczas dodawnia produktu.');
        },
      });
    } else {
      this.toastrService.error('Wystąpił błąd podczas dodawnia produktu.');
    }
  }

  calculateNutritionalValues(grams: number, prodId:number): string {
    const multiplier = grams / 100;
    console.log(grams);

    const product = this.products.find(x=> x.id == prodId); 

    if (!product) {
      return ''; 
    }
    const proteins = (product.proteins * multiplier);
    const fat = (product.fat * multiplier);
    const carbohydrates = (product.carbohydrates * multiplier);
    const calories = (product.calories * multiplier);

    this.mealFat += fat;
    this.mealProteins += proteins;
    this.mealCarbohydrates += carbohydrates;
    this.mealCalories += calories;
    console.log(product);
    return `B: ${proteins.toFixed(0)}g, T: ${fat.toFixed(0)}g, W: ${carbohydrates.toFixed(0)}g, Kcal: ${calories.toFixed(0)}`;
  }


  findTheProduct(index: number){
    const productId = this.productsInMeal.at(index).get('productId')?.value;
    const result = this.products.find(x=> x.id == productId);
    console.log(result);
    return result;
  }

  getMealNameLabel(meal: MealEnum): string {
    switch (meal) {
      case MealEnum.Default:
        return 'Brak';
      case MealEnum.Breakfast:
        return 'Śniadanie';
      case MealEnum.SecondBreakfast:
        return 'Drugie śniadanie';
      case MealEnum.Lunch:
        return 'Obiad';
      case MealEnum.Snack:
        return 'Przekąska';
      case MealEnum.Dinner:
        return 'Kolacja';
      default:
        return 'Brak';
    }
  }
}
