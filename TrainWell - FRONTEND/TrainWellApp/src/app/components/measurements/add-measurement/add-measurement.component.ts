import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MeasurementsService } from 'src/app/services/measurements.service';

@Component({
  selector: 'app-measurement',
  templateUrl: './add-measurement.component.html',
  styleUrls: ['./add-measurement.component.css']
})
export class AddMeasurementComponent implements OnInit{

  measurementForm!:FormGroup;
  constructor(private formBuilder: FormBuilder,private measurementService: MeasurementsService,private toastrService: ToastrService) {}
  ngOnInit() {
    this.initForm();
    
  }

  initForm(){
    this.measurementForm = this.formBuilder.group({
      date: ['', [Validators.required]],
      shoulders: [''],
      chest: [''],
      waist: [''],
      arm: [''],
      hips: [''],
      thigh: [''],
      weight: ['',[Validators.required]],
    });
  }


  submit() {
    console.log(this.measurementForm.value);
    if (this.measurementForm.valid) {
      const userData = this.measurementForm.value;
        this.measurementService
          .addMeasurement(userData)
          .subscribe({
            next: () => {
              this.toastrService.success("Pomiar został poprawnie dodany.");
            },
            error: (error) => {
              this.toastrService.error("Wystąpił błąd podczas dodawnia pomairu.");
            },
          });
    }else{
      this.toastrService.error("Wystąpił błąd podczas dodawnia pomairu.");
    }
  }


}
