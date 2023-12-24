import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MeasurementDto } from 'src/app/Models/measurements/MeasurementDto';
import { MeasurementsService } from 'src/app/services/workouts/measurements.service';

@Component({
  selector: 'app-edit-measurement',
  templateUrl: './edit-measurement.component.html',
  styleUrls: ['./edit-measurement.component.css'],
})
export class EditMeasurementComponent implements OnInit {
  measurementForm!: FormGroup;
  measurementId: number = 0;

  constructor(
    private formBuilder: FormBuilder,
    private measurementService: MeasurementsService,
    private toastrService: ToastrService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  initForm() {
    this.measurementForm = this.formBuilder.group({
      date: ['', [Validators.required]],
      shoulders: [''],
      chest: [''],
      waist: [''],
      arm: [''],
      hips: [''],
      thigh: [''],
      weight: ['', [Validators.required]],
    });
  }

  fetchForm() {
    this.measurementService
      .getMeasurementById(this.measurementId)
      .subscribe((downloadedMeasurement) => {
        this.measurementForm.patchValue({
          date: downloadedMeasurement.date,
          shoulders: downloadedMeasurement.shoulders,
          chest: downloadedMeasurement.chest,
          waist: downloadedMeasurement.waist,
          arm: downloadedMeasurement.arm,
          hips: downloadedMeasurement.hips,
          thigh: downloadedMeasurement.thigh,
          weight: downloadedMeasurement.weight,
        });
      });
  }
  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam !== null) {
      this.measurementId = +idParam;
    } else {
      this.toastrService.error('Błąd podczas pobierania id!');
    }
    this.initForm();
    this.fetchForm();
  }
  submit() {
    if (this.measurementForm.valid) {
      const updatedMeasurement: MeasurementDto = {
        id: this.measurementId,
        date: this.measurementForm.value.date,
        shoulders: this.measurementForm.value.shoulders,
        chest: this.measurementForm.value.chest,
        waist: this.measurementForm.value.waist,
        arm: this.measurementForm.value.arm,
        hips: this.measurementForm.value.hips,
        thigh: this.measurementForm.value.thigh,
        weight: this.measurementForm.value.weight,
      };
  
      this.measurementService
        .updateMeasurement(updatedMeasurement)
        .subscribe(
          (response) => {
            this.toastrService.success('Pomiary ciała zostały zaktualizowane pomyślnie.');
            this.router.navigate(['/kalendarz-dieta']);
          },
          (error) => {
            this.toastrService.error('Wystąpił błąd podczas aktualizacji pomiarów ciała.');
            console.error(error);
          }
        );
    } else {
      this.toastrService.error('Formularz zawiera błędy. Sprawdź poprawność wprowadzonych danych.');
    }
  }
  

  cancel() {
    this.router.navigate(['/kalendarz-dieta']);
  }
}
