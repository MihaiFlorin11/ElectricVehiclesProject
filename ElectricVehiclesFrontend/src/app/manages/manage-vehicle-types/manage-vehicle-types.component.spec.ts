import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageVehicleTypesComponent } from './manage-vehicle-types.component';

describe('ManageVehicleTypesComponent', () => {
  let component: ManageVehicleTypesComponent;
  let fixture: ComponentFixture<ManageVehicleTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageVehicleTypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageVehicleTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
