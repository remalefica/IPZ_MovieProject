import { Film } from "./film";
import { User } from "./user";

export class CommentFilm{
        public id: number;
        public filmId: number;
        public film?: Film;
        public userId: string;
        public username: string;
        public user?: User;
        public text: string;
        public createdAt: Date;

}