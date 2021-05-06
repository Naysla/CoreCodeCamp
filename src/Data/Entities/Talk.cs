namespace CoreCodeCamp.Data
{
  public class Talk
  {
    public int TalkId { get; set; }
    public Camp Camp { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public int Level { get; set; }
    //Se llama una coleccion de otra entidad que se relaciona con esta
     public Speaker Speaker { get; set; }
  }
}