﻿namespace Taskills.WebAppMVC.Models;

public class PlaceListItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string TagsString { get; set; }
}