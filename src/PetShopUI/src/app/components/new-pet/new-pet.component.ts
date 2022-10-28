import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Owner } from 'src/app/interfaces/Owner';
import { HealthStateEnum } from '../../enums/HealthStateEnum';
import { Accommodation } from '../../interfaces/Accommodation';
import { Pet } from '../../interfaces/Pet';
import { AccommodationService } from '../../services/accommodation.service';
import { PetService } from '../../services/pet.service';

@Component({
  selector: 'app-new-pet',
  templateUrl: './new-pet.component.html',
  styleUrls: ['./new-pet.component.css']
})
export class NewPetComponent implements OnInit {
  freeAccommodations: Accommodation[] = [];
  healthState = HealthStateEnum;
  keys: any[];

  petForm = this.fb.group({
    accommodationSelected: [null, Validators.required],
    healthStateSelected: [null, Validators.required],
    petName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
    reasonForTreatment: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
    ownerName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
    ownerPhone: ['', Validators.compose([Validators.required, Validators.pattern('[0-9 ]{9}')])],
    ownerAddress: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])]
  });

  constructor(
    private router: Router,
    private accommodationService: AccommodationService,
    private petService: PetService,
    private fb: FormBuilder)
  {
    this.keys = Object.keys(this.healthState).filter(Number);
  }

  ngOnInit(): void {
    this.accommodationService.getFreeAccommodation()
      .subscribe((data: Accommodation[]) => this.freeAccommodations = data);
  }

  onSubmit() {
    let newPet: Pet =  this.createPetAndOwner();
    this.addPet(newPet);
  }

  addPet(pet: Pet) {
    this.petService.addPet(pet)
      .subscribe({
        next: () => {
          alert("Saved successfully!");
          this.router.navigate(['/']);
        },
        error: () => alert('There was an error!')
      })
  }

  createPetAndOwner(): Pet{
    let newOwner: Owner = {
      name: this.petForm.value.ownerName,
      phone: this.petForm.value.ownerPhone,
      address: this.petForm.value.ownerAddress
    };

    let newPet: Pet = {
      id: 0,
      name: this.petForm.value.petName,
      reasonForTreatment: this.petForm.value.reasonForTreatment,
      heathState: this.petForm.value.healthStateSelected,
      ownerDTO: newOwner,
      accommodationNumber: this.petForm.value.accommodationSelected
    };

    return newPet;
  }
}
