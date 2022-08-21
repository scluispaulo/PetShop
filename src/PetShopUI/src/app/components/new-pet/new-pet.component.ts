import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
  HealthState = HealthStateEnum;
  keys: any[];

  accommodationSelected!: number;
  healthStateSelected!: number;
  petName!: string;
  reasonForTreatment!: string;
  ownerId: number = 0;
  ownerName!: string;
  ownerPhone!: string;
  ownerAddress!: string;
  
  constructor(
    private router: Router,
    private accommodationService: AccommodationService,
    private petService: PetService) { 
    this.keys = Object.keys(this.HealthState).filter(Number);
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

  ngOnInit(): void {
    this.accommodationService.getFreeAccommodation()
      .subscribe((data: Accommodation[]) => this.freeAccommodations = data);
  }

  AccommodationSelected(event: any): void {
    this.accommodationSelected = event.target.value;
  }
  
  HealthStateSelected(event: any): void {
    this.healthStateSelected = event.target.value;
  }

  onSubmit() {
    let newPet!: any;

    if (this.ownerId == 0) {
      newPet = this.createPetAndOwner()
    } else {
      newPet = this.createPet()
    }

    this.addPet(newPet);
  }

  createPetAndOwner(): object{
    let newOwner = {
      name: this.ownerName,
      phone: this.ownerPhone,
      address: this.ownerAddress
    }
    
    let newPet: Pet = {
      id: 0,
      name: this.petName,
      reasonForTreatment: this.reasonForTreatment,
      heathState: this.healthStateSelected,
      image: " ",
      ownerDTO: newOwner,
      accommodationNumber: this.accommodationSelected
    };

    return newPet;
  }

  createPet(): object{
    let newPet: Pet = {
      id: 0,
      name: this.petName,
      reasonForTreatment: this.reasonForTreatment,
      heathState: this.healthStateSelected,
      image: " ",
      ownerId: this.ownerId,
      accommodationNumber: this.accommodationSelected
    };

    return newPet;
  }
}
