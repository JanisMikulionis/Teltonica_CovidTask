import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewdataformComponent } from './newdataform.component';

describe('NewdataformComponent', () => {
  let component: NewdataformComponent;
  let fixture: ComponentFixture<NewdataformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewdataformComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewdataformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
