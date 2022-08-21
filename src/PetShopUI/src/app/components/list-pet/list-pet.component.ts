import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pet } from 'src/app/interfaces/Pet';
import { Router } from '@angular/router';

import { PetService } from '../../services/pet.service';

@Component({
  selector: 'app-list-pet',
  templateUrl: './list-pet.component.html',
  styleUrls: ['./list-pet.component.css']
})
export class ListPetComponent implements OnInit {
  @Input() findPet: Pet[] = [];
  @Input() showResult: boolean = false;
  @Output() selectedPet: EventEmitter<Pet> = new EventEmitter();

  constructor(private petService: PetService,
    private router: Router){}

  ngOnInit(): void {
  }

  deletePet(petId: number): void {
    this.petService.deletePet(petId).subscribe(
      () => this.filterFindPet(petId),
      error => {
        alert(`Error: ${error.statusText}`);
        this.router.navigate(['/']);}
    );
  }

  filterFindPet(petId: number): void {
    this.findPet = this.findPet.filter((pet) => pet.id !== petId);
  }

  editPet(petId: number): void {
    this.selectedPet.emit(this.findPet.find((pet) => pet.id === petId));
  }
}