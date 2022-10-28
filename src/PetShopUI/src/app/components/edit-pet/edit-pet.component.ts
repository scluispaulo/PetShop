import { Component, OnInit, Input } from '@angular/core';
import { Pet } from 'src/app/interfaces/Pet';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { HealthStateEnum } from '../../enums/HealthStateEnum';
import { Accommodation } from '../../interfaces/Accommodation';
import { PetService } from '../../services/pet.service';
import { AccommodationService } from '../../services/accommodation.service';

@Component({
  selector: 'app-edit-pet',
  templateUrl: './edit-pet.component.html',
  styleUrls: ['./edit-pet.component.css']
})
export class EditPetComponent implements OnInit {
  freeAccommodations: Accommodation[] = [];
  HealthState = HealthStateEnum;
  keys: any[];
  selectedPet!: Pet;
  emptyPet: Pet = {
    id: 0,
    name: '',
    reasonForTreatment: '',
    heathState: 0,
    accommodationNumber: 0
  };

  petForm = this.fb.group({
    accommodationSelected: [null, Validators.required],
    healthStateSelected: [null, Validators.required],
    petName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
    reasonForTreatment: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])]
  });

  constructor(
    private petService: PetService,
    private accommodationService: AccommodationService,
    private router: Router,
    private fb: FormBuilder)
  {
    this.keys = Object.keys(this.HealthState).filter(Number);
  }

  ngOnInit(): void {
    this.accommodationService.getFreeAccommodation()
      .subscribe((data: Accommodation[]) => this.freeAccommodations = data);

    this.petService.selectedPet.subscribe(pet => {
      if (pet.id !== 0) {
        this.petForm.patchValue({
          accommodationSelected: pet.accommodationNumber,
          healthStateSelected: pet.heathState,
          petName: pet.name,
          reasonForTreatment: pet.reasonForTreatment
        });

        this.selectedPet = pet;
      }
    });
  }

  onEditPet(): void {
    const pet: Pet = this.fillPet();

    this.petService.updatePet(pet).subscribe(
      () => {
        alert('Update sucessful!');
        this.router.navigate(['/']);
      },
      error => {
        alert(`Error: ${error.statusText}`);
        this.router.navigate(['/']);
      },
      () => this.petService.selectedPet.next(this.emptyPet)
    );
  }

  fillPet(): Pet {
    return {
      id: this.selectedPet.id,
      ownerId: this.selectedPet.ownerId,
      name: this.petForm.value.petName,
      reasonForTreatment: this.petForm.value.reasonForTreatment,
      heathState: this.petForm.value.healthStateSelected,
      accommodationNumber: this.petForm.value.accommodationSelected
    };
  }

  onCancel(): void {
    this.petService.selectedPet.next(this.emptyPet);
    this.router.navigate(['/']);
  }
}
