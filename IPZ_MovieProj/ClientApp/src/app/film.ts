export class Film{
    constructor(
        public id?: number,
        public name?: string,
        public filmImgPath?: string,
        public filmTrailerPath?: string,
        public year?: number,
        public durationInMinutes?: number,
        public description?: string,
        public director?: string,
        public originCountry?: string,
        public budget?: number,
        public ratingAvg?: number,
        public comments?: CommentFilm[],
        public votes?: Vote[],
        public genre?: Genre[] 
    ){}
}