import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { AddMeasurementComponent } from './add-measurement.component';
import { MeasurementsService } from 'src/app/services/workouts/measurements.service';
import { MeasurementDto } from 'src/app/Models/measurements/MeasurementDto';

describe('AddMeasurementComponent', () => {
  let component: AddMeasurementComponent;
  let fixture: ComponentFixture<AddMeasurementComponent>;
  let measurementsServiceSpy: jasmine.SpyObj<MeasurementsService>;
  let toastrServiceSpy: jasmine.SpyObj<ToastrService>;

  beforeEach(() => {
    measurementsServiceSpy = jasmine.createSpyObj('MeasurementsService', ['addMeasurement']);
    toastrServiceSpy = jasmine.createSpyObj('ToastrService', ['success', 'error']);

    TestBed.configureTestingModule({
      declarations: [AddMeasurementComponent],
      imports: [ReactiveFormsModule],
      providers: [
        { provide: MeasurementsService, useValue: measurementsServiceSpy },
        { provide: ToastrService, useValue: toastrServiceSpy }
      ]
    });

    fixture = TestBed.createComponent(AddMeasurementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize form', () => {
    expect(component.measurementForm).toBeTruthy();
  });

  it('should call addMeasurement method on submit', fakeAsync(() => {
    const userData = {
        date: '2024-01-06',
        shoulders: 40,
        chest: 90,
        waist: 75,
        arm: 30,
        hips: 95,
        thigh: 50,
        weight: 70
    };

    component.measurementForm.setValue(userData);
    measurementsServiceSpy.addMeasurement.and.returnValue(of({}));

    component.submit();
    tick();
    const expectedUserData = jasmine.objectContaining(userData);

    expect(measurementsServiceSpy.addMeasurement).toHaveBeenCalledWith(expectedUserData);
    expect(toastrServiceSpy.success).toHaveBeenCalledWith('Pomiar został poprawnie dodany.');
  }));

  it('should show error toastr if form is invalid on submit', () => {
    spyOn(component['toastrService'], 'error');

    component.submit();

    expect(component['toastrService'].error).toHaveBeenCalledWith('Wystąpił błąd podczas dodawnia pomairu.');
  });
});
