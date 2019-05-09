import { Film } from "./film";
import { User } from "./user";

export class CommentFilm{
    constructor(
        public id?: number,
        public filmId?: number,
        public film?: Film,
        public userId?: number,
        public user?: User,
        public text?: number,
        public createdAt?: Date
    ){}
}