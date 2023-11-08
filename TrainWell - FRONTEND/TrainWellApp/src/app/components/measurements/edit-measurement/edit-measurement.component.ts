import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MeasurementsService } from 'src/app/services/measurements.service';

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
  submit() {}

  cancel() {
    this.router.navigate(['/treningi']);
  }
}
