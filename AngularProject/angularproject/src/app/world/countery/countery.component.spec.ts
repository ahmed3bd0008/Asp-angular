/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CounteryComponent } from './countery.component';

describe('CounteryComponent', () => {
  let component: CounteryComponent;
  let fixture: ComponentFixture<CounteryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CounteryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CounteryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
