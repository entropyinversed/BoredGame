namespace  BoredGameV2.Model;

public sealed record Snapshot(
    Mark[,] Cells,
    Outcome Outcome,
    Mark PlayToMove
);