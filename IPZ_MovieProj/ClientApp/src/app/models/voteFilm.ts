import { Film } from "./film";
import { User } from "./user";

export class VoteFilm{
    constructor(
        public id?: number,
        public filmId?: number,
        public film?: Film,
        public userId?: string,
        public user?: User,
        public rating?: number
    ){}
}