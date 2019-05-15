import { Film } from "./film";
import { User } from "./user";

export class CommentFilm{
    constructor(
        public id?: number,
        public filmId?: number,
        public userId?: number,
        public text?: string,
        public createdAt?: Date
    ){}
}