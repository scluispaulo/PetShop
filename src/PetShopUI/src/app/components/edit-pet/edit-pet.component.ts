import { Component, OnInit, Input } from '@angular/core';
import { Pet } from 'src/app/interfaces/Pet';
import { Router } from '@angular/router';

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
  @Input() selectedPet!: Pet;
  freeAccommodations: Accommodation[] = [];
  HealthState = HealthStateEnum;
  keys: any[];

  constructor(private petService: PetService,
    private accommodationService: AccommodationService,
    private router: Router){
      this.keys = Object.keys(this.HealthState).filter(Number);
    }

  ngOnInit(): void {
    this.accommodationService.getFreeAccommodation()
    .subscribe((data: Accommodation[]) => this.freeAccommodations = data);
  }

  AccommodationSelected(event: any): void {
    this.selectedPet.accommodationNumber = event.target.value;
  }
  
  HealthStateSelected(event: any): void {
    this.selectedPet.heathState = event.target.value;
  }

  onEditPet(): void {
    this.petService.updatePet(this.selectedPet).subscribe(
      () => {
        alert('Update sucessful!');
        this.router.navigate(['/']);
      },
      error => {
        alert(`Error: ${error.statusText}`);
        this.router.navigate(['/']);}
    );
  }
}
