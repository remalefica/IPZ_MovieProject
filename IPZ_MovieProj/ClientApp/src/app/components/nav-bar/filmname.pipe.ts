import { Pipe, PipeTransform } from "@angular/core";
import { Film } from "src/app/models";


@Pipe({name: 'filmSearch'})
export class FilmSearchPipe implements PipeTransform{
    transform(value: Film[], exponent: string): Film[]{
        let filmsResult = [];

        value.forEach(film => {
            if(film.name.toLowerCase().includes(exponent.toLowerCase())){
                filmsResult.push(film);
            }
        });

        return filmsResult;
    }
}