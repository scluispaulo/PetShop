import { Component, OnInit,EventEmitter, Input } from '@angular/core';
import { Pet } from 'src/app/interfaces/Pet';
import { Router } from '@angular/router';

import { PetService } from '../../services/pet.service';

@Component({
  selector: 'app-search-pet',
  templateUrl: './search-pet.component.html',
  styleUrls: ['./search-pet.component.css']
})
export class SearchPetComponent implements OnInit {
  petName!: string;
  findPet: Pet[] = [];
  showResult: boolean = false;
  selectedPet!: Pet;

  constructor(private petService: PetService,
    private router: Router) { }

  ngOnInit(): void {
  }

  searchPet(){
    this.petService.searchPet(this.petName).subscribe(
      (data: Pet[]) => {
        this.findPet = data;
        this.showResult = true;},
      error => {
        alert(`Error: ${error.statusText}`);
        this.router.navigate(['/']);}
    );
  }

  onSelectedPet(pet: Pet){
    this.selectedPet = pet;
  }
}
