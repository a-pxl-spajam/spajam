﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDecoratable
{
  GameObject Decorate(List<Pair> effectList);
}
